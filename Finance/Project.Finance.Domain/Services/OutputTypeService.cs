using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Domain.Services;

public class OutputTypeService(IOutputTypeRepository repository) : IOutputTypeService
{
    public Task<List<OutputType>> GetAll()
    {
        return repository.GetAll();
    }

    public Task<OutputType?> GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public Task<OutputType> Insert(OutputType entity)
    {
        return repository.Insert(entity);
    }

    public Task<OutputType> Update(Guid id, OutputType entity)
    {
        return repository.Update(id, entity);
    }
    public Task<OutputType> Delete(Guid id)
    {
        return repository.Delete(id);
    }
}
