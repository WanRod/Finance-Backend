using FluentValidation;
using Project.Finance.Application.Commands.Output;
using Project.Finance.Infrastructure;

namespace Project.Finance.Application.Validations.Output;

public class OutputUpdateValidator : AbstractValidator<OutputUpdateRequest>
{
    private readonly FinanceDbContext _dbContext;

    public OutputUpdateValidator(FinanceDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(validation => validation).Custom(OutputUpdateValidations);
    }

    private void OutputUpdateValidations(OutputUpdateRequest request, ValidationContext<OutputUpdateRequest> context)
    {
        request.Description = request.Description.Trim();

        if (request.Id == Guid.Empty)
        {
            context.AddFailure("O id da Saída é obrigatório.");
        }
        else
        {
            var outputExists = _dbContext.OutputDbSet.Where(e => e.Id == request.Id).Any();

            if (!outputExists)
            {
                context.AddFailure("A Saída não foi encontrada.");
            }
        }

        if (request.OutputTypeId == Guid.Empty)
        {
            context.AddFailure("O Tipo de Saída é obrigatório.");
        }
        else
        {
            var outputTypeExists = _dbContext.OutputTypeDbSet.Where(e => e.Id == request.OutputTypeId).Any();

            if (!outputTypeExists)
            {
                context.AddFailure("O tipo de Saída não foi encontrado.");
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
            context.AddFailure("O valor da Saída não pode ser 0.");
        }
    }
}
