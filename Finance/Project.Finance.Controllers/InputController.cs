using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.Input;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/input")]
public class InputController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<List<InputResponse>> GetAll()
    {
        return await mediator.Send(new InputGetAllRequest());
    }

    [HttpGet("{id}")]
    public async Task<InputResponse> GetById(Guid id)
    {
        return await mediator.Send(new InputGetByIdRequest(id));
    }

    [HttpPost]
    public async Task<InputResponse> Insert([FromBody] InputInsertRequest request)
    {
        return await mediator.Send(request);
    }

    [HttpPut]
    public async Task<InputResponse> Update([FromBody] InputUpdateRequest request)
    {
        return await mediator.Send(request);
    }

    [HttpDelete("{id}")]
    public async Task<InputResponse> Delete(Guid id)
    {
        return await mediator.Send(new InputDeleteRequest(id));
    }
}
