using MediatR;
using Project.Finance.Application.Commands.Login;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Login;

public class LoginHandler(IUserService userService, IAuthenticationService authenticationService) : IRequestHandler<LoginRequest, LoginResponse>
{
    private string ClearCpfCnpj(string cpfCnpj)
    {
        return cpfCnpj.Replace(".", "").Replace("-", "").Replace("/", "");
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        request.CpfCnpj = ClearCpfCnpj(request.CpfCnpj);

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

    private void Validations()
    {

    }
}
