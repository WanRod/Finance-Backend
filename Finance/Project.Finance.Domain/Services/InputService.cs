using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Domain.Services;

public class InputService(IInputRepository repository) : IInputService
{
    public Task<List<Input>> GetAll(int? quantity)
    {
        return repository.GetAll(quantity);
    }

    public Task<Input?> GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public async Task Insert(Input entity)
    {
        await repository.Insert(entity);
    }

    public async Task Update(Guid id, Input entity)
    {
        await repository.Update(id, entity);
    }
    public async Task Delete(Guid id)
    {
        await repository.Delete(id);
    }
}
