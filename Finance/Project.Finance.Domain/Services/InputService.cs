using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Domain.Services;

public class InputService(IInputRepository repository) : IInputService
{
    public async Task<List<Input>> GetAll()
    {
        return await repository.GetAll();
    }

    public async Task<Input?> GetById(Guid id)
    {
        return await repository.GetById(id);
    }

    public async Task<Input> Insert(Input entity)
    {
        return await repository.Insert(entity);
    }

    public async Task<Input> Update(Guid id, Input entity)
    {
        return await repository.Update(id, entity);
    }
    public async Task<Input> Delete(Guid id)
    {
        return await repository.Delete(id);
    }
}
