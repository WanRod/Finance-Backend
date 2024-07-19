using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Input;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Input;

public class InputUpdateHandler(IInputService service, IMapper mapper) : IRequestHandler<InputUpdateRequest, InputResponse>
{
    public async Task<InputResponse> Handle(InputUpdateRequest request, CancellationToken cancellationToken)
    {
        var input = mapper.Map<Domain.Entites.Input>(request);
        var inputUpdated = await service.Update(input.Id, input);
        return mapper.Map<InputResponse>(inputUpdated);
    }
}
