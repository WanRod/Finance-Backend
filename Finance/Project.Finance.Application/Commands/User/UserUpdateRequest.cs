using MediatR;
using Project.Finance.Domain.Interfaces;

namespace Project.Finance.Application.Commands.User;

public class UserUpdateRequest : IRequest
{
    public Guid Id { get; private set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public void SetUserContext(IUserContext userContext)
    {
        Id = userContext.UserId;
    }
}
