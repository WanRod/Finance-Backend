using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces;
using Project.Finance.Domain.Interfaces.Repositories;

namespace Project.Finance.Infrastructure.Repositories;

public class OutputTypeRepository(FinanceDbContext dbContext, IUserContext userContext) : IOutputTypeRepository
{
    public IQueryable<OutputType> AsQueryable()
    {
        return dbContext.OutputTypeDbSet.Where(e => e.CreatedBy == userContext.UserId)
                                        .AsQueryable();
    }

    public async Task<List<OutputType>> GetAll(int? quantity = null)
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

    public async Task<OutputType?> GetById(Guid id)
    {
        return await AsQueryable().SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task Insert(OutputType entity)
    {
        if (entity.CreatedBy == Guid.Empty)
        {
            entity.CreatedBy = userContext.UserId;
        }

        dbContext.OutputTypeDbSet.Add(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Guid id, OutputType entity)
    {
        var currentyEntity = await GetById(id) ??
            throw new Exception("O Tipo de Saída não foi encontrado.");

        entity.CreatedBy = currentyEntity.CreatedBy;

        dbContext.Update(currentyEntity).CurrentValues.SetValues(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await GetById(id) ??
            throw new Exception("O Tipo de Saída não foi encontrado.");

        dbContext.OutputTypeDbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}
