using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Services;

public interface IInputService
{
    Task<List<Input>> GetAll(int quantity = 20);

    Task<Input?> GetById(Guid id);

    Task Insert(Input entity);

    Task Update(Guid id, Input entity);

    Task Delete(Guid id);
}
