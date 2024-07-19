using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Repositories;

public interface IOutputRepository
{
    Task<List<Output>> GetAll();

    Task<Output?> GetById(Guid id);

    Task<Output> Insert(Output entity);

    Task<Output> Update(Guid id, Output entity);

    Task<Output> Delete(Guid id);
}
