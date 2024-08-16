using MediatR;

namespace Project.Finance.Application.Commands.Input;

public class InputDeleteRequest(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}
