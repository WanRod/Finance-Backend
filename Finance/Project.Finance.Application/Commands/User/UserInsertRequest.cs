using MediatR;

namespace Project.Finance.Application.Commands.User;

public class UserInsertRequest : IRequest
{
    public required string Name { get; set; }

    public required string CpfCnpj { get; set; }

    public required string Password { get; set; }
}
