using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Domain.Services;

public class DashboardService(IDashboardRepository repository) : IDashboardService
{
    public Task<Dashboard> GetData(int year, int month)
    {
        return repository.GetData(year, month);
    }
}
