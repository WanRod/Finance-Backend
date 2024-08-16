using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Output;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Output;

public class OutputUpdateHandler(IOutputService service, IMapper mapper) : IRequestHandler<OutputUpdateRequest>
{
    public async Task Handle(OutputUpdateRequest request, CancellationToken cancellationToken)
    {
        var output = mapper.Map<Domain.Entites.Output>(request);
        await service.Update(output.Id, output);
    }
}
