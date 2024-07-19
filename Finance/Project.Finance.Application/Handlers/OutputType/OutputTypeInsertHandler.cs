using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.OutputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.OutputType;

public class OutputTypeInsertHandler(IOutputTypeService service, IMapper mapper) : IRequestHandler<OutputTypeInsertRequest, OutputTypeResponse>
{
    public async Task<OutputTypeResponse> Handle(OutputTypeInsertRequest request, CancellationToken cancellationToken)
    {
        var outputType = mapper.Map<Domain.Entites.OutputType>(request);
        var outputTypeInserted = await service.Insert(outputType);
        return mapper.Map<OutputTypeResponse>(outputTypeInserted);
    }
}
