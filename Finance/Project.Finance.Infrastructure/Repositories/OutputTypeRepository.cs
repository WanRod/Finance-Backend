using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces;
using Project.Finance.Domain.Interfaces.Repositories;

namespace Project.Finance.Infrastructure.Repositories;

public class OutputTypeRepository(FinanceDbContext dbContext, IUserContext userContext) : IOutputTypeRepository
{
    public async Task<List<OutputType>> GetAll(int? quantity = null)
    {
        if (quantity is not null)
        {
            return await dbContext.OutputTypeDbSet.Where(e => e.CreatedBy == userContext.UserId).OrderBy(e => e.Description).Take((int)quantity).ToListAsync();
        }

        return await dbContext.OutputTypeDbSet.Where(e => e.CreatedBy == userContext.UserId).OrderBy(e => e.Description).ToListAsync();
    }

    public async Task<OutputType?> GetById(Guid id)
    {
        return await dbContext.OutputTypeDbSet.FindAsync(id);
    }

    public async Task Insert(OutputType entity)
    {
        entity.CreatedBy = userContext.UserId;

        dbContext.OutputTypeDbSet.Add(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Guid id, OutputType entity)
    {
        var currentyEntity = await dbContext.OutputTypeDbSet.FindAsync(id) ?? throw new Exception("O tipo de saída não foi encontrado.");
        entity.CreatedBy = currentyEntity.CreatedBy;

        dbContext.Update(currentyEntity).CurrentValues.SetValues(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await dbContext.OutputTypeDbSet.FindAsync(id) ?? throw new Exception("O tipo de saída não foi encontrado.");

        dbContext.OutputTypeDbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}
