using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project.Finance.Domain.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Project.Finance.Domain.Services;

public class AuthenticationService(IUserService userService, IConfiguration configuration) : IAuthenticationService
{
    private const string _salt = "fsdgghfghgjngh";

    public async Task<bool> Authentication(string cpfCnpj, string password)
    {
        var user = await userService.GetByCpfCnpj(cpfCnpj);

        if (user is null)
        {
            return false;
        }

        using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(_salt));
        var computeHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

        if (computeHash != user.Password)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> UserExists(string cpfCnpj)
    {
        var user = await userService.GetByCpfCnpj(cpfCnpj);

        if (user is null)
        {
            return false;
        }

        return true;
    }

    public string GenerateToken(Guid id, string cpfCnpj)
    {
        var claims = new[]
        {
            new Claim("id", id.ToString()),
            new Claim("cpfCnpj", cpfCnpj),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(120);

        JwtSecurityToken token = new(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
