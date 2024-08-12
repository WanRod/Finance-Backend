using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.Input;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/input")]
public class InputController(IMediator mediator)
{
    [HttpGet]
    public Task<List<InputResponse>> GetAll()
    {
        return mediator.Send(new InputGetAllRequest());
    }

    [HttpGet("{id}")]
    public Task<InputResponse> GetById(Guid id)
    {
        return mediator.Send(new InputGetByIdRequest(id));
    }

    [HttpPost]
    public Task<InputResponse> Insert([FromBody] InputInsertRequest request)
    {
        return mediator.Send(request);
    }

    [HttpPut]
    public Task<InputResponse> Update([FromBody] InputUpdateRequest request)
    {
        return mediator.Send(request);
    }

    [HttpDelete("{id}")]
    public Task<InputResponse> Delete(Guid id)
    {
        return mediator.Send(new InputDeleteRequest(id));
    }
}
