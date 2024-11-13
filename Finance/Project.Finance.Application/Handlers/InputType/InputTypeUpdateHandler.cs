using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.InputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.InputType;

public class InputTypeUpdateHandler(IInputTypeService service, IMapper mapper) : IRequestHandler<InputTypeUpdateRequest>
{
    public async Task Handle(InputTypeUpdateRequest request, CancellationToken cancellationToken)
    {
        var inputType = mapper.Map<Domain.Entites.InputType>(request);
        await service.Update(inputType.Id, inputType);
    }
}
