using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Services;

public interface IUserService
{
    Task<User?> GetById(Guid id);

    Task<User?> GetByCpfCnpj(string cpfCnpj);

    Task Insert(User entity);

    Task Update(Guid id, User entity);

    Task Delete(Guid id);
}
