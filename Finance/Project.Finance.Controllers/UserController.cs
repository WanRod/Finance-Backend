using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.User;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/user")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    [Authorize]
    public Task<UserResponse> GetById(Guid id)
    {
        return mediator.Send(new UserGetByIdRequest(id));
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
        await mediator.Send(request);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new UserDeleteRequest(id));

        return Ok();
    }
}
