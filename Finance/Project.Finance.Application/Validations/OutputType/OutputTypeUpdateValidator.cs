using FluentValidation;
using Project.Finance.Application.Commands.OutputType;
using Project.Finance.Domain.Interfaces;
using Project.Finance.Infrastructure;

namespace Project.Finance.Application.Validations.OutputType;

public class OutputTypeUpdateValidator : AbstractValidator<OutputTypeUpdateRequest>
{
    private readonly FinanceDbContext _dbContext;
    private readonly IUserContext _userContext;

    public OutputTypeUpdateValidator(FinanceDbContext dbContext, IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;

        RuleFor(validation => validation).Custom(OutputTypeUpdateValidations);
    }

    private void OutputTypeUpdateValidations(OutputTypeUpdateRequest request, ValidationContext<OutputTypeUpdateRequest> context)
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
            var descriptionAlreadyExists = _dbContext.OutputTypeDbSet.Where(e => e.Id != request.Id && e.Description.ToLower() == request.Description.ToLower() && e.CreatedBy == _userContext.UserId).Any();

            if (descriptionAlreadyExists)
            {
                context.AddFailure("Você já tem um Tipo de Saída com essa descrição.");
            }
        }
    }
}
