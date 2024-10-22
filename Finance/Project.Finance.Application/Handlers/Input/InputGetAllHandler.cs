using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Input;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Input;

public class InputGetAllHandler(IInputService service, IMapper mapper) : IRequestHandler<InputGetAllRequest, List<InputResponse>>
{
    public async Task<List<InputResponse>> Handle(InputGetAllRequest request, CancellationToken cancellationToken)
    {
        var inputs = await service.GetAll(request.Quantity);
        return mapper.Map<List<InputResponse>>(inputs);
    }
}
