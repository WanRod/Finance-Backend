using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Domain.Services;

public class InputService(IInputRepository repository) : IInputService
{
    public Task<List<Input>> GetAll()
    {
        return repository.GetAll();
    }

    public Task<Input?> GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public Task<Input> Insert(Input entity)
    {
        return repository.Insert(entity);
    }

    public Task<Input> Update(Guid id, Input entity)
    {
        return repository.Update(id, entity);
    }
    public Task<Input> Delete(Guid id)
    {
        return repository.Delete(id);
    }
}
