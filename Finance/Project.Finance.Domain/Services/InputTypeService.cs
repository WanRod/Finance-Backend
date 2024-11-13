using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Domain.Services;

public class InputTypeService(IInputTypeRepository repository) : IInputTypeService
{
    public Task<List<InputType>> GetAll(int? quantity = null)
    {
        return repository.GetAll(quantity);
    }

    public Task<InputType?> GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public async Task Insert(InputType entity)
    {
        await repository.Insert(entity);
    }

    public async Task Update(Guid id, InputType entity)
    {
        await repository.Update(id, entity);
    }
    public async Task Delete(Guid id)
    {
        await repository.Delete(id);
    }
}
