using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Input;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Input;

public class InputGetByIdHandler(IInputService service, IMapper mapper) : IRequestHandler<InputGetByIdRequest, InputResponse>
{
    public async Task<InputResponse> Handle(InputGetByIdRequest request, CancellationToken cancellationToken)
    {
        var input = await service.GetById(request.Id);
        return mapper.Map<InputResponse>(input);
    }
}
