using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Output;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Output;

public class OutputGetAllHandler(IOutputService service, IMapper mapper) : IRequestHandler<OutputGetAllRequest, List<OutputResponse>>
{
    public async Task<List<OutputResponse>> Handle(OutputGetAllRequest request, CancellationToken cancellationToken)
    {
        var outputs = await service.GetAll(request.Quantity);
        return mapper.Map<List<OutputResponse>>(outputs);
    }
}
