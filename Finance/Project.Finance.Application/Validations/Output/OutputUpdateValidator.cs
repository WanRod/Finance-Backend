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
            context.AddFailure("O id da saída é obrigatório.");
        }
        else
        {
            var outputExists = _dbContext.OutputDbSet.Where(e => e.Id == request.Id).Any();

            if (!outputExists)
            {
                context.AddFailure("A saída não foi encontrada.");
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
