using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.OutputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.OutputType;

public class OutputTypeGetByIdHandler(IOutputTypeService service, IMapper mapper) : IRequestHandler<OutputTypeGetByIdRequest, OutputTypeResponse>
{
    public async Task<OutputTypeResponse> Handle(OutputTypeGetByIdRequest request, CancellationToken cancellationToken)
    {
        var outputType = await service.GetById(request.Id);
        return mapper.Map<OutputTypeResponse>(outputType);
    }
}
