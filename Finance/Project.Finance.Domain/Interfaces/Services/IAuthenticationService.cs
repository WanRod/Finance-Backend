namespace Project.Finance.Domain.Interfaces.Services;

public interface IAuthenticationService
{
    Task<bool> Authentication(string cpfCnpj, string password);

    Task<bool> UserExists(string cpfCnpj);

    string GenerateToken(Guid id, string cpfCnpj);
}
