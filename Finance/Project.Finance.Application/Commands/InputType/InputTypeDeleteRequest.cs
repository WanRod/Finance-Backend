using MediatR;

namespace Project.Finance.Application.Commands.InputType;

public class InputTypeDeleteRequest(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}
