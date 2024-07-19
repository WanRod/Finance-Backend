using MediatR;

namespace Project.Finance.Application.Commands.Input;

public class InputGetByIdRequest(Guid id) : IRequest<InputResponse>
{
    public Guid Id { get; } = id;
}
