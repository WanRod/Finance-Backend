using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Output;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Output;

public class OutputInsertHandler(IOutputService service, IMapper mapper) : IRequestHandler<OutputInsertRequest>
{
    public async Task Handle(OutputInsertRequest request, CancellationToken cancellationToken)
    {
        var output = mapper.Map<Domain.Entites.Output>(request);
        await service.Insert(output);
    }
}
