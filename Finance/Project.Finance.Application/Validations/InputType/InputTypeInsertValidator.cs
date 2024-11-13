using FluentValidation;
using Project.Finance.Application.Commands.InputType;
using Project.Finance.Domain.Interfaces;
using Project.Finance.Infrastructure;

namespace Project.Finance.Application.Validations.InputType;

public class InputTypeInsertValidator : AbstractValidator<InputTypeInsertRequest>
{
    private readonly FinanceDbContext _dbContext;
    private readonly IUserContext _userContext;

    public InputTypeInsertValidator(FinanceDbContext dbContext, IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;

        RuleFor(validation => validation).Custom(InputTypeInsertValidations);
    }

    private void InputTypeInsertValidations(InputTypeInsertRequest request, ValidationContext<InputTypeInsertRequest> context)
    {
        request.Description = request.Description.Trim();

        if (string.IsNullOrEmpty(request.Description))
        {
            context.AddFailure("A descrição é obrigatória.");
        }
        else if (request.Description.Length > 100)
        {
            context.AddFailure("O comprimento máximo da descrição é de 100 caracteres.");
        }
        else
        {
            var descriptionAlreadyExists = _dbContext.InputTypeDbSet.Where(e => e.Description.ToLower() == request.Description.ToLower() && e.CreatedBy == _userContext.UserId).Any();

            if (descriptionAlreadyExists)
            {
                context.AddFailure("Você já tem um Tipo de Entrada com essa descrição.");
            }
        }
    }
}
