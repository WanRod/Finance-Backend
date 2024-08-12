using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Repositories;

public interface IDashboardRepository
{
    Task<Dashboard> GetData(int year, int month);
}
