using FluentValidation;
using Project.Finance.Application.Commands.User;
using Project.Finance.Infrastructure;

namespace Project.Finance.Application.Validations.User;

public class UserInsertValidator : AbstractValidator<UserInsertRequest>
{
    private readonly FinanceDbContext _dbContext;

    public UserInsertValidator(FinanceDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(validation => validation).Custom(UserInsertValidations);
    }

    private void UserInsertValidations(UserInsertRequest request, ValidationContext<UserInsertRequest> context)
    {
        request.Name = request.Name.Trim();
        request.CpfCnpj = request.CpfCnpj.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
        request.Password = request.Password.Trim();

        if (string.IsNullOrEmpty(request.Name))
        {
            context.AddFailure("O nome é obrigatório.");
        }

        if (request.CpfCnpj.Length != 11 && request.CpfCnpj.Length != 14)
        {
            context.AddFailure("CPF ou CNPJ inválido.");
        }
        else
        {
            var userExists = _dbContext.UserDbSet.Where(e => e.CpfCnpj == request.CpfCnpj).Any();

            if (userExists)
            {
                context.AddFailure("Já existe um usuário com esse CPF/CNPJ.");
            }
        }

        if (string.IsNullOrEmpty(request.Password))
        {
            context.AddFailure("A senha é obrigatória.");
        }
    }
}
