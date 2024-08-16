using MediatR;

namespace Project.Finance.Application.Commands.Login;

public class LoginRequest : IRequest<LoginResponse>
{
    public required string CpfCnpj { get; set; }

    public required string Password { get; set; }
}
