using FluentValidation;
using Project.Finance.Application.Commands.Login;

namespace Project.Finance.Application.Validations.Login;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(validation => validation).Custom(LoginValidations);
    }

    private void LoginValidations(LoginRequest request, ValidationContext<LoginRequest> context)
    {
        request.CpfCnpj = request.CpfCnpj.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
        request.Password = request.Password.Trim();

        if (request.CpfCnpj.Length != 11 && request.CpfCnpj.Length != 14)
        {
            context.AddFailure("CPF ou CNPJ inválido.");
        }

        if (string.IsNullOrEmpty(request.Password))
        {
            context.AddFailure("A senha é obrigatória.");
        }
    }
}
