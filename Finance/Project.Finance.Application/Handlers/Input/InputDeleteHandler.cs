using MediatR;
using Project.Finance.Application.Commands.Input;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Input;

public class InputDeleteHandler(IInputService service) : IRequestHandler<InputDeleteRequest>
{
    public async Task Handle(InputDeleteRequest request, CancellationToken cancellationToken)
    {
        await service.Delete(request.Id);
    }
}
