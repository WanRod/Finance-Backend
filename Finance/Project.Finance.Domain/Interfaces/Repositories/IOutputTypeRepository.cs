using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Repositories;

public interface IOutputTypeRepository
{
    Task<List<OutputType>> GetAll(int? quantity = null);

    Task<OutputType?> GetById(Guid id);

    Task Insert(OutputType entity);

    Task Update(Guid id, OutputType entity);

    Task Delete(Guid id);
}
