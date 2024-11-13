using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.InputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.InputType;

public class InputTypeGetByIdHandler(IInputTypeService service, IMapper mapper) : IRequestHandler<InputTypeGetByIdRequest, InputTypeResponse>
{
    public async Task<InputTypeResponse> Handle(InputTypeGetByIdRequest request, CancellationToken cancellationToken)
    {
        var inputType = await service.GetById(request.Id);
        return mapper.Map<InputTypeResponse>(inputType);
    }
}
