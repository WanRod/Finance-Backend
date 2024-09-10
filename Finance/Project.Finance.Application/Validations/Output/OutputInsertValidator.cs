using FluentValidation;
using Project.Finance.Application.Commands.Output;
using Project.Finance.Infrastructure;

namespace Project.Finance.Application.Validations.Output;

public class OutputInsertValidator : AbstractValidator<OutputInsertRequest>
{
    private readonly FinanceDbContext _dbContext;

    public OutputInsertValidator(FinanceDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(validation => validation).Custom(OutputInsertValidations);
    }

    private void OutputInsertValidations(OutputInsertRequest request, ValidationContext<OutputInsertRequest> context)
    {
        request.Description = request.Description.Trim();

        if (string.IsNullOrEmpty(request.Description))
        {
            context.AddFailure("A descrição é obrigatória.");
        }

        if (request.Value == 0)
        {
            context.AddFailure("O valor da saída não pode ser 0.");
        }

        if (request.OutputTypeId == Guid.Empty)
        {
            context.AddFailure("O tipo de saída é obrigatório.");
        }
        else
        {
            var outputTypeExists = _dbContext.OutputTypeDbSet.Where(e => e.Id == request.OutputTypeId).Any();

            if (!outputTypeExists)
            {
                context.AddFailure("O tipo de saída não foi encontrado.");
            }
        }
    }
}
