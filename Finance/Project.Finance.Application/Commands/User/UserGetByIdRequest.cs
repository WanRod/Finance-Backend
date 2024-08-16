using MediatR;

namespace Project.Finance.Application.Commands.User;

public class UserGetByIdRequest(Guid id) : IRequest<UserResponse>
{
    public Guid Id { get; } = id;
}
