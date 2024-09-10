using FluentValidation;
using Project.Finance.Application.Commands.Input;
using Project.Finance.Infrastructure;

namespace Project.Finance.Application.Validations.Input;

public class InputUpdateValidator : AbstractValidator<InputUpdateRequest>
{
    private readonly FinanceDbContext _dbContext;

    public InputUpdateValidator(FinanceDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(validation => validation).Custom(InputUpdateValidations);
    }

    private void InputUpdateValidations(InputUpdateRequest request, ValidationContext<InputUpdateRequest> context)
    {
        request.Description = request.Description.Trim();

        if (request.Id == Guid.Empty)
        {
            context.AddFailure("O id da entrada é obrigatório.");
        }
        else
        {
            var inputExists = _dbContext.InputDbSet.Where(e => e.Id == request.Id).Any();

            if (!inputExists)
            {
                context.AddFailure("A entrada não foi encontrada.");
            }
        }

        if (string.IsNullOrEmpty(request.Description))
        {
            context.AddFailure("A descrição é obrigatória.");
        }

        if (request.Value == 0)
        {
            context.AddFailure("O valor da saída não pode ser 0.");
        }
    }
}
