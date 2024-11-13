using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces;
using Project.Finance.Domain.Interfaces.Repositories;

namespace Project.Finance.Infrastructure.Repositories;

public class InputTypeRepository(FinanceDbContext dbContext, IUserContext userContext) : IInputTypeRepository
{
    public IQueryable<InputType> AsQueryable()
    {
        return dbContext.InputTypeDbSet.Where(e => e.CreatedBy == userContext.UserId)
                                       .AsQueryable();
    }

    public async Task<List<InputType>> GetAll(int? quantity = null)
    {
        if (quantity is not null)
        {
            return await AsQueryable().OrderBy(e => e.Description)
                                      .Take((int)quantity)
                                      .ToListAsync();
        }

        return await AsQueryable().OrderBy(e => e.Description)
                                             .ToListAsync();
    }

    public async Task<InputType?> GetById(Guid id)
    {
        return await AsQueryable().SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task Insert(InputType entity)
    {
        if (entity.CreatedBy == Guid.Empty)
        {
            entity.CreatedBy = userContext.UserId;
        }

        dbContext.InputTypeDbSet.Add(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Guid id, InputType entity)
    {
        var currentyEntity = await GetById(id) ??
            throw new Exception("O Tipo de Entrada não foi encontrado.");

        entity.CreatedBy = currentyEntity.CreatedBy;

        dbContext.Update(currentyEntity).CurrentValues.SetValues(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await GetById(id) ??
            throw new Exception("O Tipo de Entrada não foi encontrado.");

        dbContext.InputTypeDbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}
