using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Domain.Services;

public class OutputService(IOutputRepository repository) : IOutputService
{
    public async Task<List<Output>> GetAll()
    {
        return await repository.GetAll();
    }

    public async Task<Output?> GetById(Guid id)
    {
        return await repository.GetById(id);
    }

    public async Task<Output> Insert(Output entity)
    {
        return await repository.Insert(entity);
    }

    public async Task<Output> Update(Guid id, Output entity)
    {
        return await repository.Update(id, entity);
    }
    public async Task<Output> Delete(Guid id)
    {
        return await repository.Delete(id);
    }
}
