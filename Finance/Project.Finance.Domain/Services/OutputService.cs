using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Domain.Services;

public class OutputService(IOutputRepository repository) : IOutputService
{
    public Task<List<Output>> GetAll(int quantity)
    {
        return repository.GetAll(quantity);
    }

    public Task<Output?> GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public async Task Insert(Output entity)
    {
        if (entity.Value > 0)
        {
            entity.Value *= -1;
        }

        await repository.Insert(entity);
    }

    public async Task Update(Guid id, Output entity)
    {
        if (entity.Value > 0)
        {
            entity.Value *= -1;
        }

        await repository.Update(id, entity);
    }
    public async Task Delete(Guid id)
    {
        await repository.Delete(id);
    }
}
