using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.OutputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.OutputType;

public class OutputTypeGetAllHandler(IOutputTypeService service, IMapper mapper) : IRequestHandler<OutputTypeGetAllRequest, List<OutputTypeResponse>>
{
    public async Task<List<OutputTypeResponse>> Handle(OutputTypeGetAllRequest request, CancellationToken cancellationToken)
    {
        var outputTypes = await service.GetAll(request.Quantity);
        return mapper.Map<List<OutputTypeResponse>>(outputTypes);
    }
}
