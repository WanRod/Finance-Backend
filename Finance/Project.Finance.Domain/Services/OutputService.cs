using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Domain.Services;

public class OutputService(IOutputRepository repository) : IOutputService
{
    public Task<List<Output>> GetAll()
    {
        return repository.GetAll();
    }

    public Task<Output?> GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public Task<Output> Insert(Output entity)
    {
        return repository.Insert(entity);
    }

    public Task<Output> Update(Guid id, Output entity)
    {
        return repository.Update(id, entity);
    }
    public Task<Output> Delete(Guid id)
    {
        return repository.Delete(id);
    }
}
