using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.InputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.InputType;

public class InputTypeInsertHandler(IInputTypeService service, IMapper mapper) : IRequestHandler<InputTypeInsertRequest>
{
    public async Task Handle(InputTypeInsertRequest request, CancellationToken cancellationToken)
    {
        var inputType = mapper.Map<Domain.Entites.InputType>(request);
        await service.Insert(inputType);
    }
}
