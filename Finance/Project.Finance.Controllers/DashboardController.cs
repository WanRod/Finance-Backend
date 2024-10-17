using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.Dashboard;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/dashboard")]
public class DashboardController(IMediator mediator)
{
    [HttpGet("available-years")]
    [Authorize]
    public Task<List<int>> GetAvailableYears()
    {
        return mediator.Send(new DashboardGetAvailableYearsRequest());
    }

    [HttpGet("data")]
    [Authorize]
    public Task<DashboardResponse> GetData([FromQuery] DashboardGetDataRequest request)
    {
        return mediator.Send(request);
    }
}
