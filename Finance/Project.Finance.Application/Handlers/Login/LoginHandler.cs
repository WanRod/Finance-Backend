using MediatR;
using Project.Finance.Application.Commands.Login;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Login;

public class LoginHandler(IUserService userService, IAuthenticationService authenticationService) : IRequestHandler<LoginRequest, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await userService.GetByCpfCnpj(request.CpfCnpj) ??
            throw new Exception("User does not exists");

        var authenticationSuccess = await authenticationService.Authentication(request.CpfCnpj, request.Password);

        if (!authenticationSuccess)
        {
            throw new Exception("Failed to authenticate");
        }

        return new LoginResponse()
        {
            Token = authenticationService.GenerateToken(user.Id, request.CpfCnpj)
        };
    }
}
