using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.Output;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/output")]
public class OutputController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<List<OutputResponse>> GetAll()
    {
        return await mediator.Send(new OutputGetAllRequest());
    }

    [HttpGet("{id}")]
    public async Task<OutputResponse> GetById(Guid id)
    {
        return await mediator.Send(new OutputGetByIdRequest(id));
    }

    [HttpPost]
    public async Task<OutputResponse> Insert([FromBody] OutputInsertRequest request)
    {
        return await mediator.Send(request);
    }

    [HttpPut]
    public async Task<OutputResponse> Update([FromBody] OutputUpdateRequest request)
    {
        return await mediator.Send(request);
    }

    [HttpDelete("{id}")]
    public async Task<OutputResponse> Delete(Guid id)
    {
        return await mediator.Send(new OutputDeleteRequest(id));
    }
}
