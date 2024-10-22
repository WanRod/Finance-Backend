using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.OutputType;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/output-type")]
public class OutputTypeController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public Task<List<OutputTypeResponse>> GetAll([FromQuery] OutputTypeGetAllRequest request)
    {
        return mediator.Send(request);
    }

    [HttpGet("{id}")]
    [Authorize]
    public Task<OutputTypeResponse> GetById(Guid id)
    {
        return mediator.Send(new OutputTypeGetByIdRequest(id));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Insert([FromBody] OutputTypeInsertRequest request)
    {
        await mediator.Send(request);
        Response.StatusCode = 201;
        return Created();
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] OutputTypeUpdateRequest request)
    {
        await mediator.Send(request);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new OutputTypeDeleteRequest(id));

        return Ok();
    }
}
