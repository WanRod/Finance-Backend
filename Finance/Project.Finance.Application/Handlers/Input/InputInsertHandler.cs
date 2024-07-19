using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Input;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Input;

public class InputInsertHandler(IInputService service, IMapper mapper) : IRequestHandler<InputInsertRequest, InputResponse>
{
    public async Task<InputResponse> Handle(InputInsertRequest request, CancellationToken cancellationToken)
    {
        var input = mapper.Map<Domain.Entites.Input>(request);
        var inputInserted = await service.Insert(input);
        return mapper.Map<InputResponse>(inputInserted);
    }
}
