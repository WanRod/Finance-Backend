using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Repositories;

public interface IInputTypeRepository
{
    Task<List<InputType>> GetAll(int? quantity = null);

    Task<InputType?> GetById(Guid id);

    Task Insert(InputType entity);

    Task Update(Guid id, InputType entity);

    Task Delete(Guid id);
}
