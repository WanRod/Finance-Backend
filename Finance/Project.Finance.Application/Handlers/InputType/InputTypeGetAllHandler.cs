using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.InputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.InputType;

public class InputTypeGetAllHandler(IInputTypeService service, IMapper mapper) : IRequestHandler<InputTypeGetAllRequest, List<InputTypeResponse>>
{
    public async Task<List<InputTypeResponse>> Handle(InputTypeGetAllRequest request, CancellationToken cancellationToken)
    {
        var inputTypes = await service.GetAll(request.Quantity);
        return mapper.Map<List<InputTypeResponse>>(inputTypes);
    }
}
