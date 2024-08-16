using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Input;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Input;

public class InputUpdateHandler(IInputService service, IMapper mapper) : IRequestHandler<InputUpdateRequest>
{
    public async Task Handle(InputUpdateRequest request, CancellationToken cancellationToken)
    {
        var input = mapper.Map<Domain.Entites.Input>(request);
        await service.Update(input.Id, input);
    }
}
