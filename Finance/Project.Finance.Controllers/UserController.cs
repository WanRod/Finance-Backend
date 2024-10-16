using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.User;
using Project.Finance.Domain.Interfaces;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/user")]
public class UserController(IMediator mediator, IUserContext userContext) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public Task<UserResponse> GetData()
    {
        return mediator.Send(new UserGetDataRequest(userContext.UserId));
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] UserInsertRequest request)
    {
        await mediator.Send(request);
        Response.StatusCode = 201;
        return Created();
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] UserUpdateRequest request)
    {
        request.SetUserContext(userContext);

        await mediator.Send(request);

        return Ok();
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete()
    {
        await mediator.Send(new UserDeleteRequest(userContext.UserId));

        return Ok();
    }
}
