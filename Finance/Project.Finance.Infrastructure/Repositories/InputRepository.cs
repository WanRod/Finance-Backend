using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;

namespace Project.Finance.Infrastructure.Repositories;

public class InputRepository(FinanceDbContext dbContext) : IInputRepository
{
    public async Task<List<Input>> GetAll()
    {
        return await dbContext.InputDbSet.OrderByDescending(e => e.Date).Take(20).ToListAsync();
    }

    public async Task<Input?> GetById(Guid id)
    {
        return await dbContext.InputDbSet.FindAsync(id);
    }

    public async Task<Input> Insert(Input entity)
    {
        dbContext.InputDbSet.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<Input> Update(Guid id, Input entity)
    {
        var currentyEntity = await dbContext.InputDbSet.FindAsync(id) ?? throw new Exception();

        dbContext.Update(currentyEntity).CurrentValues.SetValues(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<Input> Delete(Guid id)
    {
        var entity = await dbContext.InputDbSet.FindAsync(id) ?? throw new Exception();

        dbContext.InputDbSet.Remove(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }
}
