namespace Project.Finance.Application.Commands.User;

public class UserResponse
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string CpfCnpj { get; set; }
}
