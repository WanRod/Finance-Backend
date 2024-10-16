using MediatR;

namespace Project.Finance.Application.Commands.Dashboard;

public class DashboardGetDataRequest : IRequest<DashboardResponse>
{
    public int Year { get; set; }

    public int Month { get; set; }
}
