using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.Output;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/output")]
public class OutputController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public Task<List<OutputResponse>> GetAll([FromQuery] OutputGetAllRequest request)
    {
        return mediator.Send(request);
    }

    [HttpGet("{id}")]
    [Authorize]
    public Task<OutputResponse> GetById(Guid id)
    {
        return mediator.Send(new OutputGetByIdRequest(id));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Insert([FromBody] OutputInsertRequest request)
    {
        await mediator.Send(request);
        Response.StatusCode = 201;
        return Created();
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] OutputUpdateRequest request)
    {
        await mediator.Send(request);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new OutputDeleteRequest(id));

        return Ok();
    }
}
