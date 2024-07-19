using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Output;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Output;

public class OutputUpdateHandler(IOutputService service, IMapper mapper) : IRequestHandler<OutputUpdateRequest, OutputResponse>
{
    public async Task<OutputResponse> Handle(OutputUpdateRequest request, CancellationToken cancellationToken)
    {
        if (request.Value > 0)
        {
            request.Value *= -1;
        }

        var output = mapper.Map<Domain.Entites.Output>(request);
        var outputUpdated = await service.Update(output.Id, output);
        return mapper.Map<OutputResponse>(outputUpdated);
    }
}
