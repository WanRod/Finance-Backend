using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;

namespace Project.Finance.Infrastructure.Repositories;

public class OutputRepository(FinanceDbContext dbContext) : IOutputRepository
{
    public IQueryable<Output> AsQueryable()
    {
        return dbContext.OutputDbSet
            .Include(e => e.OutputType)
            .AsQueryable();
    }

    public async Task<List<Output>> GetAll()
    {
        return await AsQueryable().OrderByDescending(e => e.Date).ToListAsync();
    }

    public async Task<Output?> GetById(Guid id)
    {
        return await AsQueryable().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Output> Insert(Output entity)
    {
        dbContext.OutputDbSet.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<Output> Update(Guid id, Output entity)
    {
        var currentyEntity = await AsQueryable().FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception();

        dbContext.Update(currentyEntity).CurrentValues.SetValues(entity);
        await dbContext.SaveChangesAsync();

        return currentyEntity;
    }

    public async Task<Output> Delete(Guid id)
    {
        var entity = await AsQueryable().FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception();

        dbContext.OutputDbSet.Remove(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }
}
