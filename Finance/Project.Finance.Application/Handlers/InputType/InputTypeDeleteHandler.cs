using MediatR;
using Project.Finance.Application.Commands.InputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.InputType;

public class InputTypeDeleteHandler(IInputTypeService service) : IRequestHandler<InputTypeDeleteRequest>
{
    public async Task Handle(InputTypeDeleteRequest request, CancellationToken cancellationToken)
    {
        await service.Delete(request.Id);
    }
}
