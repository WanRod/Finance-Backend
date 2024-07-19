using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Domain.Services;

public class OutputTypeService(IOutputTypeRepository repository) : IOutputTypeService
{
    public async Task<List<OutputType>> GetAll()
    {
        return await repository.GetAll();
    }

    public async Task<OutputType?> GetById(Guid id)
    {
        return await repository.GetById(id);
    }

    public async Task<OutputType> Insert(OutputType entity)
    {
        return await repository.Insert(entity);
    }

    public async Task<OutputType> Update(Guid id, OutputType entity)
    {
        return await repository.Update(id, entity);
    }
    public async Task<OutputType> Delete(Guid id)
    {
        return await repository.Delete(id);
    }
}
