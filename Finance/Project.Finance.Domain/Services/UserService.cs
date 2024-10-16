using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace Project.Finance.Domain.Services;

public class UserService(IUserRepository repository) : IUserService
{
    private const string _salt = "fsdgghfghgjngh";

    public async Task<User?> GetData(Guid id)
    {
        var data = await repository.GetData(id);

        if (data is not null)
        {
            using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(_salt));
            var computeHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(data.Password)));
        }

        return data;
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
        var currentUser = await GetData(id) ??
           throw new Exception("Não foi possível encontrar o usuário.");

        if (string.IsNullOrEmpty(entity.Name))
        {
            entity.Name = currentUser.Name;
        }

        if (string.IsNullOrEmpty(entity.Password))
        {
            entity.Password = currentUser.Password;
        }
        else
        {
            using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(_salt));
            entity.Password = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(entity.Password)));
        }

        entity.CpfCnpj = currentUser.CpfCnpj;

        await repository.Update(id, entity);
    }

    public async Task Delete(Guid id)
    {
        await repository.Delete(id);
    }
}
