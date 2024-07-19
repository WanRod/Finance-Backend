using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.OutputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.OutputType;

public class OutputTypeUpdateHandler(IOutputTypeService service, IMapper mapper) : IRequestHandler<OutputTypeUpdateRequest, OutputTypeResponse>
{
    public async Task<OutputTypeResponse> Handle(OutputTypeUpdateRequest request, CancellationToken cancellationToken)
    {
        var outputType = mapper.Map<Domain.Entites.OutputType>(request);
        var outputTypeUpdated = await service.Update(outputType.Id, outputType);
        return mapper.Map<OutputTypeResponse>(outputTypeUpdated);
    }
}
