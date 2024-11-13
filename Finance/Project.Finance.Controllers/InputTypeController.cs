using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.InputType;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/input-type")]
public class InputTypeController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public Task<List<InputTypeResponse>> GetAll([FromQuery] InputTypeGetAllRequest request)
    {
        return mediator.Send(request);
    }

    [HttpGet("{id}")]
    [Authorize]
    public Task<InputTypeResponse> GetById(Guid id)
    {
        return mediator.Send(new InputTypeGetByIdRequest(id));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Insert([FromBody] InputTypeInsertRequest request)
    {
        await mediator.Send(request);
        Response.StatusCode = 201;
        return Created();
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] InputTypeUpdateRequest request)
    {
        await mediator.Send(request);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new InputTypeDeleteRequest(id));

        return Ok();
    }
}
