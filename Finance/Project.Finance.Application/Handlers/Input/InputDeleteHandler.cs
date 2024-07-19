using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Input;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Input;

public class InputDeleteHandler(IInputService service, IMapper mapper) : IRequestHandler<InputDeleteRequest, InputResponse>
{
    public async Task<InputResponse> Handle(InputDeleteRequest request, CancellationToken cancellationToken)
    {
        var input = await service.Delete(request.Id);
        return mapper.Map<InputResponse>(input);
    }
}
