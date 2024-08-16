using MediatR;

namespace Project.Finance.Application.Commands.Dashboard;

public class DashboardGetDataRequest(int year, int month) : IRequest<DashboardResponse>
{
    public int Year { get; } = year;

    public int Month { get; } = month;
}
