using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Input;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Input;

public class InputInsertHandler(IInputService service, IMapper mapper) : IRequestHandler<InputInsertRequest>
{
    public async Task Handle(InputInsertRequest request, CancellationToken cancellationToken)
    {
        var input = mapper.Map<Domain.Entites.Input>(request);
        await service.Insert(input);
    }
}
