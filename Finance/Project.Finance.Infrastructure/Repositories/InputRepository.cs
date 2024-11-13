using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces;
using Project.Finance.Domain.Interfaces.Repositories;

namespace Project.Finance.Infrastructure.Repositories;

public class InputRepository(FinanceDbContext dbContext, IUserContext userContext) : IInputRepository
{
    public IQueryable<Input> AsQueryable()
    {
        return dbContext.InputDbSet.Include(e => e.InputType)
                                   .Where(e => e.CreatedBy == userContext.UserId)
                                   .AsQueryable();
    }

    public async Task<List<Input>> GetAll(int? quantity)
    {
        if (quantity is not null)
        {
            return await AsQueryable().OrderByDescending(e => e.Date)
                                  .Take((int)quantity)
                                  .ToListAsync();
        }

        return await AsQueryable().OrderByDescending(e => e.Date)
                                  .ToListAsync();
    }

    public async Task<Input?> GetById(Guid id)
    {
        return await AsQueryable().SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task Insert(Input entity)
    {
        if (entity.CreatedBy == Guid.Empty)
        {
            entity.CreatedBy = userContext.UserId;
        }

        dbContext.InputDbSet.Add(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Guid id, Input entity)
    {
        var currentyEntity = await GetById(id) ??
            throw new Exception("A Entrada não foi encontrada.");

        entity.CreatedBy = currentyEntity.CreatedBy;

        dbContext.Update(currentyEntity).CurrentValues.SetValues(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await GetById(id) ??
            throw new Exception("A Entrada não foi encontrada.");

        dbContext.InputDbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}
