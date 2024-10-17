using MediatR;
using Project.Finance.Application.Commands.Dashboard;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Dashboard;

public class DashboardGetAvailableYearsHandler(IDashboardService service) : IRequestHandler<DashboardGetAvailableYearsRequest, List<int>>
{
    public Task<List<int>> Handle(DashboardGetAvailableYearsRequest request, CancellationToken cancellationToken)
    {
        return service.GetAvailableYears();
    }
}
