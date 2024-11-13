using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;

namespace Project.Finance.Infrastructure.Repositories;

public class UserRepository(FinanceDbContext dbContext) : IUserRepository
{
    public IQueryable<User> AsQueryable()
    {
        return dbContext.UserDbSet.AsQueryable();
    }

    public async Task<User?> GetData(Guid id)
    {
        return await AsQueryable().SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<User?> GetByCpfCnpj(string cpfCnpj)
    {
        return await AsQueryable().SingleOrDefaultAsync(e => e.CpfCnpj == cpfCnpj);
    }

    public async Task<User> Insert(User entity)
    {
        var user = dbContext.UserDbSet.Add(entity);
        await dbContext.SaveChangesAsync();

        return user.Entity;
    }

    public async Task Update(Guid id, User entity)
    {
        var currentyEntity = await AsQueryable().SingleOrDefaultAsync(e => e.Id == id) ??
            throw new Exception("O usuário não foi encontrado.");

        dbContext.Update(currentyEntity).CurrentValues.SetValues(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await AsQueryable().SingleOrDefaultAsync(e => e.Id == id) ??
            throw new Exception("O usuário não foi encontrado.");

        dbContext.UserDbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}
