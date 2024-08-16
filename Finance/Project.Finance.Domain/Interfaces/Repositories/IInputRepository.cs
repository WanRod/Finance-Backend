using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Repositories;

public interface IInputRepository
{
    Task<List<Input>> GetAll();

    Task<Input?> GetById(Guid id);

    Task Insert(Input entity);

    Task Update(Guid id, Input entity);

    Task Delete(Guid id);
}
