using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.OutputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.OutputType;

public class OutputTypeInsertHandler(IOutputTypeService service, IMapper mapper) : IRequestHandler<OutputTypeInsertRequest>
{
    public async Task Handle(OutputTypeInsertRequest request, CancellationToken cancellationToken)
    {
        var outputType = mapper.Map<Domain.Entites.OutputType>(request);
        await service.Insert(outputType);
    }
}
