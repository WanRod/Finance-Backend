using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.OutputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.OutputType;

public class OutputTypeUpdateHandler(IOutputTypeService service, IMapper mapper) : IRequestHandler<OutputTypeUpdateRequest>
{
    public async Task Handle(OutputTypeUpdateRequest request, CancellationToken cancellationToken)
    {
        var outputType = mapper.Map<Domain.Entites.OutputType>(request);
        await service.Update(outputType.Id, outputType);
    }
}
