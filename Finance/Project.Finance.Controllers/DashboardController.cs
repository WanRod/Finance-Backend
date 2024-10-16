using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.Dashboard;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/dashboard")]
public class DashboardController(IMediator mediator)
{
    [HttpGet("data")]
    [Authorize]
    public Task<DashboardResponse> GetData([FromQuery] DashboardGetDataRequest request)
    {
        return mediator.Send(request);
    }
}
