using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Repositories;

public interface IOutputRepository
{
    Task<List<Output>> GetAll(int quantity = 20);

    Task<Output?> GetById(Guid id);

    Task Insert(Output entity);

    Task Update(Guid id, Output entity);

    Task Delete(Guid id);
}
