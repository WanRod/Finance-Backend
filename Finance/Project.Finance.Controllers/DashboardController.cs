using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.Dashboard;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/dashboard")]
public class DashboardController(IMediator mediator)
{
    [HttpGet("data/{year}/{month}")]
    [Authorize]
    public Task<DashboardResponse> GetData(int year, int month)
    {
        return mediator.Send(new DashboardGetDataRequest(year, month));
    }
}
