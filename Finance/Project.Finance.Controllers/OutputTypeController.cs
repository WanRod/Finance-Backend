using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.OutputType;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/output-type")]
public class OutputTypeController(IMediator mediator)
{
    [HttpGet]
    public Task<List<OutputTypeResponse>> GetAll()
    {
        return mediator.Send(new OutputTypeGetAllRequest());
    }

    [HttpGet("{id}")]
    public Task<OutputTypeResponse> GetById(Guid id)
    {
        return mediator.Send(new OutputTypeGetByIdRequest(id));
    }

    [HttpPost]
    public Task<OutputTypeResponse> Insert([FromBody] OutputTypeInsertRequest request)
    {
        return mediator.Send(request);
    }

    [HttpPut]
    public Task<OutputTypeResponse> Update([FromBody] OutputTypeUpdateRequest request)
    {
        return mediator.Send(request);
    }

    [HttpDelete("{id}")]
    public Task<OutputTypeResponse> Delete(Guid id)
    {
        return mediator.Send(new OutputTypeDeleteRequest(id));
    }
}
