using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.Output;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/output")]
public class OutputController(IMediator mediator)
{
    [HttpGet]
    public Task<List<OutputResponse>> GetAll()
    {
        return mediator.Send(new OutputGetAllRequest());
    }

    [HttpGet("{id}")]
    public Task<OutputResponse> GetById(Guid id)
    {
        return mediator.Send(new OutputGetByIdRequest(id));
    }

    [HttpPost]
    public Task<OutputResponse> Insert([FromBody] OutputInsertRequest request)
    {
        return mediator.Send(request);
    }

    [HttpPut]
    public Task<OutputResponse> Update([FromBody] OutputUpdateRequest request)
    {
        return mediator.Send(request);
    }

    [HttpDelete("{id}")]
    public Task<OutputResponse> Delete(Guid id)
    {
        return mediator.Send(new OutputDeleteRequest(id));
    }
}
