using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces;
using Project.Finance.Domain.Interfaces.Repositories;

namespace Project.Finance.Infrastructure.Repositories;

public class InputRepository(FinanceDbContext dbContext, IUserContext userContext) : IInputRepository
{
    public async Task<List<Input>> GetAll(int quantity = 20)
    {
        return await dbContext.InputDbSet.Where(e => e.CreatedBy == userContext.UserId).OrderByDescending(e => e.Date).Take(quantity).ToListAsync();
    }

    public async Task<Input?> GetById(Guid id)
    {
        return await dbContext.InputDbSet.FindAsync(id);
    }

    public async Task Insert(Input entity)
    {
        entity.CreatedBy = userContext.UserId;

        dbContext.InputDbSet.Add(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Guid id, Input entity)
    {
        var currentyEntity = await dbContext.InputDbSet.FindAsync(id) ?? throw new Exception("A entrada não foi encontrada.");
        entity.CreatedBy = currentyEntity.CreatedBy;

        dbContext.Update(currentyEntity).CurrentValues.SetValues(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await dbContext.InputDbSet.FindAsync(id) ?? throw new Exception("A entrada não foi encontrada.");

        dbContext.InputDbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}
