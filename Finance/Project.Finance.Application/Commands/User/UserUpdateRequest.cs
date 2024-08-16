using MediatR;

namespace Project.Finance.Application.Commands.User;

public class UserUpdateRequest : IRequest
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Password { get; set; }
}
