using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.Input;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/input")]
public class InputController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public Task<List<InputResponse>> GetAll([FromQuery] InputGetAllRequest request)
    {
        return mediator.Send(request);
    }

    [HttpGet("{id}")]
    [Authorize]
    public Task<InputResponse> GetById(Guid id)
    {
        return mediator.Send(new InputGetByIdRequest(id));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Insert([FromBody] InputInsertRequest request)
    {
        await mediator.Send(request);
        Response.StatusCode = 201;
        return Created();
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] InputUpdateRequest request)
    {
        await mediator.Send(request);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new InputDeleteRequest(id));

        return Ok();
    }
}
