using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Repositories;

public interface IInputRepository
{
    Task<List<Input>> GetAll();

    Task<Input?> GetById(Guid id);

    Task<Input> Insert(Input entity);

    Task<Input> Update(Guid id, Input entity);

    Task<Input> Delete(Guid id);
}
