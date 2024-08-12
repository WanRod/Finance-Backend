using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Dashboard;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Dashboard;

public class DashboardGetDataHandler(IDashboardService service, IMapper mapper) : IRequestHandler<DashboardGetDataRequest, DashboardResponse>
{
    public async Task<DashboardResponse> Handle(DashboardGetDataRequest request, CancellationToken cancellationToken)
    {
        var dashboardData = await service.GetData(request.Year, request.Month);
        return mapper.Map<DashboardResponse>(dashboardData);
    }
}
