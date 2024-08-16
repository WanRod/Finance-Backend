using MediatR;

namespace Project.Finance.Application.Commands.User;

public class UserDeleteRequest(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}
