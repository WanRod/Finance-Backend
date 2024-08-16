using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Services;

public interface IOutputService
{
    Task<List<Output>> GetAll();

    Task<Output?> GetById(Guid id);

    Task Insert(Output entity);

    Task Update(Guid id, Output entity);

    Task Delete(Guid id);
}
