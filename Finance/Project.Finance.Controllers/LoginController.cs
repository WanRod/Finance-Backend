using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.Login;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<LoginResponse> Login([FromBody] LoginRequest request)
    {
        return await mediator.Send(request);
    }
}
