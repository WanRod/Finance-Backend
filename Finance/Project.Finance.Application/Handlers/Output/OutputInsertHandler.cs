using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Output;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Output;

public class OutputInsertHandler(IOutputService service, IMapper mapper) : IRequestHandler<OutputInsertRequest, OutputResponse>
{
    public async Task<OutputResponse> Handle(OutputInsertRequest request, CancellationToken cancellationToken)
    {
        if (request.Value > 0)
        {
            request.Value *= -1;
        }

        var output = mapper.Map<Domain.Entites.Output>(request);
        var outputInserted = await service.Insert(output);
        return mapper.Map<OutputResponse>(outputInserted);
    }
}
