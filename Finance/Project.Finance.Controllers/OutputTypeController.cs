using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Finance.Application.Commands.OutputType;

namespace Project.Finance.Controllers;

[ApiController]
[Route("api/finance/output-type")]
public class OutputTypeController(IMediator mediator)
{
    [HttpGet]
    public async Task<List<OutputTypeResponse>> GetAll()
    {
        return await mediator.Send(new OutputTypeGetAllRequest());
    }

    [HttpGet("{id}")]
    public async Task<OutputTypeResponse> GetById(Guid id)
    {
        return await mediator.Send(new OutputTypeGetByIdRequest(id));
    }

    [HttpPost]
    public async Task<OutputTypeResponse> Insert([FromBody] OutputTypeInsertRequest request)
    {
        return await mediator.Send(request);
    }

    [HttpPut]
    public async Task<OutputTypeResponse> Update([FromBody] OutputTypeUpdateRequest request)
    {
        return await mediator.Send(request);
    }

    [HttpDelete("{id}")]
    public async Task<OutputTypeResponse> Delete(Guid id)
    {
        return await mediator.Send(new OutputTypeDeleteRequest(id));
    }
}
