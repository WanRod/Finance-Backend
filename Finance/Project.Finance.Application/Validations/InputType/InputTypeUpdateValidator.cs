using FluentValidation;
using Project.Finance.Application.Commands.InputType;
using Project.Finance.Domain.Interfaces;
using Project.Finance.Infrastructure;

namespace Project.Finance.Application.Validations.InputType;

public class InputTypeUpdateValidator : AbstractValidator<InputTypeUpdateRequest>
{
    private readonly FinanceDbContext _dbContext;
    private readonly IUserContext _userContext;

    public InputTypeUpdateValidator(FinanceDbContext dbContext, IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;

        RuleFor(validation => validation).Custom(InputTypeUpdateValidations);
    }

    private void InputTypeUpdateValidations(InputTypeUpdateRequest request, ValidationContext<InputTypeUpdateRequest> context)
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
            var descriptionAlreadyExists = _dbContext.InputTypeDbSet.Where(e => e.Id != request.Id && e.Description.ToLower() == request.Description.ToLower() && e.CreatedBy == _userContext.UserId).Any();

            if (descriptionAlreadyExists)
            {
                context.AddFailure("Você já tem um Tipo de Entrada com essa descrição.");
            }
        }
    }
}
