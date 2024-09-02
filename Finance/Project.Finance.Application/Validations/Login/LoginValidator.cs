using FluentValidation;
using Project.Finance.Application.Commands.Login;

namespace Project.Finance.Application.Validations.Login;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(validation => validation).Custom(LoginValidations);
    }

    public void LoginValidations(LoginRequest request, ValidationContext<LoginRequest> context)
    {
        request.CpfCnpj = request.CpfCnpj.Replace(".", "").Replace("-", "").Replace("/", "").Trim();

        if (request.CpfCnpj.Length != 11 && request.CpfCnpj.Length != 14)
        {
            context.AddFailure("O comprimento é inválido para um CPF ou CNPJ.");
        }

        if (context is not null)
        {
            return;
        }
    }
}
