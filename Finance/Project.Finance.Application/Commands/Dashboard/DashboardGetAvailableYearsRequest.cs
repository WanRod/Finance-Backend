using MediatR;

namespace Project.Finance.Application.Commands.Dashboard;

public class DashboardGetAvailableYearsRequest : IRequest<List<int>>
{

}
