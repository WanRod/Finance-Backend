using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;

namespace Project.Finance.Infrastructure.Repositories;

public class UserRepository(FinanceDbContext dbContext) : IUserRepository
{
    public async Task<User?> GetData(Guid id)
    {
        return await dbContext.UserDbSet.FindAsync(id);
    }

    public async Task<User?> GetByCpfCnpj(string cpfCnpj)
    {
        return await dbContext.UserDbSet.Where(e => e.CpfCnpj == cpfCnpj).SingleOrDefaultAsync();
    }

    public async Task Insert(User entity)
    {
        dbContext.UserDbSet.Add(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Guid id, User entity)
    {
        var currentyEntity = await dbContext.UserDbSet.FindAsync(id) ?? throw new Exception("O usuário não foi encontrado.");

        dbContext.Update(currentyEntity).CurrentValues.SetValues(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await dbContext.UserDbSet.FindAsync(id) ?? throw new Exception("O usuário não foi encontrado.");

        dbContext.UserDbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}
