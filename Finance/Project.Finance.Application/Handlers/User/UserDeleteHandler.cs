using MediatR;
using Project.Finance.Application.Commands.User;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.User;

public class UserDeleteHandler(IUserService service) : IRequestHandler<UserDeleteRequest>
{
    public async Task Handle(UserDeleteRequest request, CancellationToken cancellationToken)
    {
        await service.Delete(request.Id);
    }
}
