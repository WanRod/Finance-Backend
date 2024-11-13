using FluentValidation;
using Project.Finance.Application.Commands.Input;
using Project.Finance.Infrastructure;

namespace Project.Finance.Application.Validations.Input;

public class InputInsertValidator : AbstractValidator<InputInsertRequest>
{
    private readonly FinanceDbContext _dbContext;

    public InputInsertValidator(FinanceDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(validation => validation).Custom(InputInsertValidations);
    }

    private void InputInsertValidations(InputInsertRequest request, ValidationContext<InputInsertRequest> context)
    {
        request.Description = request.Description.Trim();

        if (request.InputTypeId == Guid.Empty)
        {
            context.AddFailure("O Tipo de Entrada é obrigatório.");
        }
        else
        {
            var inputTypeExists = _dbContext.InputTypeDbSet.Where(e => e.Id == request.InputTypeId).Any();

            if (!inputTypeExists)
            {
                context.AddFailure("O Tipo de Entrada não foi encontrado.");
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
