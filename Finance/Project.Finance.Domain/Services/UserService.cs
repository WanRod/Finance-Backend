using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace Project.Finance.Domain.Services;

public class UserService(IUserRepository repository) : IUserService
{
    private const string _salt = "fsdgghfghgjngh";

    public Task<User?> GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public Task<User?> GetByCpfCnpj(string cpfCnpj)
    {
        return repository.GetByCpfCnpj(cpfCnpj);
    }

    public async Task Insert(User entity)
    {
        using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(_salt));
        entity.Password = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(entity.Password)));

        await repository.Insert(entity);
    }

    public async Task Update(Guid id, User entity)
    {
        await repository.Update(id, entity);
    }

    public async Task Delete(Guid id)
    {
        await repository.Delete(id);
    }
}
