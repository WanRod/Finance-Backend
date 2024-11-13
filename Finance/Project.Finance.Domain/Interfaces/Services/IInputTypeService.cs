using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Services;

public interface IInputTypeService
{
    Task<List<InputType>> GetAll(int? quantity = null);

    Task<InputType?> GetById(Guid id);

    Task Insert(InputType entity);

    Task Update(Guid id, InputType entity);

    Task Delete(Guid id);
}
