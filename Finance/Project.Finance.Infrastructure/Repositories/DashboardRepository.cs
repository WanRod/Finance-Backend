using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces;
using Project.Finance.Domain.Interfaces.Repositories;

namespace Project.Finance.Infrastructure.Repositories;

public class DashboardRepository(FinanceDbContext dbContext, IUserContext userContext) : IDashboardRepository
{
    public async Task<Dashboard> GetData(int year, int month)
    {
        var inputOutputData = await dbContext.InputDbSet
            .Where(e => e.CreatedBy == userContext.UserId && e.Date.Year == year)
            .GroupBy(e => e.Date.Month)
            .Select(g => new
            {
                Month = g.Key,
                TotalInput = g.Sum(e => e.Value)
            })
            .ToListAsync();

        var outputData = await dbContext.OutputDbSet
            .Where(e => e.CreatedBy == userContext.UserId && e.Date.Year == year)
            .GroupBy(e => e.Date.Month)
            .Select(g => new
            {
                Month = g.Key,
                TotalOutput = g.Sum(e => e.Value)
            })
            .ToListAsync();

        var outputTypes = await dbContext.OutputDbSet
            .Where(e => e.CreatedBy == userContext.UserId && e.Date.Year == year && e.Date.Month == month)
            .GroupBy(o => o.OutputType.Description)
            .Select(g => new
            {
                Description = g.Key,
                Amount = g.Count(),
                Total = g.Sum(e => e.Value)
            })
            .OrderByDescending(x => x.Amount)
            .ThenBy(x => x.Description)
            .Take(10)
            .ToListAsync();

        var totalInput = inputOutputData.FirstOrDefault(e => e.Month == month)?.TotalInput ?? 0;
        var totalOutput = outputData.FirstOrDefault(e => e.Month == month)?.TotalOutput ?? 0;

        var dashboard = new Dashboard
        {
            TotalInput = totalInput,
            TotalOutput = totalOutput,
            PercentSpent = totalInput != 0 ? Math.Round((totalOutput / totalInput) * -100, 2) : 0,
            RemainingAmount = totalOutput > totalInput ? Math.Round(totalInput - totalOutput, 2) : Math.Round(totalInput + totalOutput, 2)
        };

        foreach (var outputType in outputTypes)
        {
            dashboard.OutputTypes.Add(new DashboardOutputTypes()
            {
                Description = outputType.Description,
                Amount = outputType.Amount,
                Total = outputType.Total,
            });
        }

        for (int i = 1; i <= 12; i++)
        {
            dashboard.Monthly.Add(new MonthlyDashboard()
            {
                Month = i,
                Input = inputOutputData.FirstOrDefault(x => x.Month == i)?.TotalInput ?? 0,
                Output = outputData.FirstOrDefault(x => x.Month == i)?.TotalOutput ?? 0
            });
        }

        return dashboard;
    }


}
