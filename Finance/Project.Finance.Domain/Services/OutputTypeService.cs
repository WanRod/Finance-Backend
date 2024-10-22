using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Domain.Services;

public class OutputTypeService(IOutputTypeRepository repository) : IOutputTypeService
{
    public Task<List<OutputType>> GetAll(int? quantity = null)
    {
        return repository.GetAll(quantity);
    }

    public Task<OutputType?> GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public async Task Insert(OutputType entity)
    {
        await repository.Insert(entity);
    }

    public async Task Update(Guid id, OutputType entity)
    {
        await repository.Update(id, entity);
    }
    public async Task Delete(Guid id)
    {
        await repository.Delete(id);
    }
}
