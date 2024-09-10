using Project.Finance.Domain.Data;

namespace Project.Finance.Domain.Interfaces.Repositories;

public interface IDashboardRepository
{
    Task<Dashboard> GetData(int year, int month);
}
