using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.OutputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.OutputType;

public class OutputTypeDeleteHandler(IOutputTypeService service, IMapper mapper) : IRequestHandler<OutputTypeDeleteRequest, OutputTypeResponse>
{
    public async Task<OutputTypeResponse> Handle(OutputTypeDeleteRequest request, CancellationToken cancellationToken)
    {
        var outputType = await service.Delete(request.Id);
        return mapper.Map<OutputTypeResponse>(outputType);
    }
}
