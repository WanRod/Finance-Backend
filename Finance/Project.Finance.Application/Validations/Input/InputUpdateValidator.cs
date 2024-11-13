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
            context.AddFailure("O id da Entrada é obrigatório.");
        }
        else
        {
            var inputExists = _dbContext.InputDbSet.Where(e => e.Id == request.Id).Any();

            if (!inputExists)
            {
                context.AddFailure("A Entrada não foi encontrada.");
            }
        }

        if (request.InputTypeId == Guid.Empty)
        {
            context.AddFailure("O Tipo de Entrada é obrigatório.");
        }
        else
        {
            var inputTypeExists = _dbContext.InputTypeDbSet.Where(e => e.Id == request.InputTypeId).Any();

            if (!inputTypeExists)
            {
                context.AddFailure("O tipo de Entrada não foi encontrado.");
            }
        }

        if (string.IsNullOrEmpty(request.Description))
        {
            context.AddFailure("A descrição é obrigatória.");
        }
        else if (request.Description.Length > 100)
        {
            context.AddFailure("O comprimento máximo da descrição é de 100 caracteres.");
        }

        if (request.Value == 0)
        {
            context.AddFailure("O valor da saída não pode ser 0.");
        }
    }
}
