using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.User;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.User;

public class UserInsertHandler(IUserService service, IAuthenticationService authenticationService, IMapper mapper) : IRequestHandler<UserInsertRequest>
{
    public async Task Handle(UserInsertRequest request, CancellationToken cancellationToken)
    {
        var userExists = await authenticationService.UserExists(request.CpfCnpj);

        if (userExists)
        {
            throw new Exception();
        }

        var user = mapper.Map<Domain.Entites.User>(request);
        await service.Insert(user);
    }
}
