using MediatR;

namespace Project.Finance.Application.Commands.InputType;

public class InputTypeGetByIdRequest(Guid id) : IRequest<InputTypeResponse>
{
    public Guid Id { get; } = id;
}
