using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;

namespace Project.Finance.Infrastructure.Repositories;

public class OutputTypeRepository(FinanceDbContext dbContext) : IOutputTypeRepository
{
    public async Task<List<OutputType>> GetAll()
    {
        return await dbContext.OutputTypeDbSet.OrderBy(e => e.Description).ToListAsync();
    }

    public async Task<OutputType?> GetById(Guid id)
    {
        return await dbContext.OutputTypeDbSet.FindAsync(id);
    }

    public async Task<OutputType> Insert(OutputType entity)
    {
        dbContext.OutputTypeDbSet.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<OutputType> Update(Guid id, OutputType entity)
    {
        var currentyEntity = await dbContext.OutputTypeDbSet.FindAsync(id) ?? throw new Exception();

        dbContext.Update(currentyEntity).CurrentValues.SetValues(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<OutputType> Delete(Guid id)
    {
        var entity = await dbContext.OutputTypeDbSet.FindAsync(id) ?? throw new Exception();

        dbContext.OutputTypeDbSet.Remove(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }
}
