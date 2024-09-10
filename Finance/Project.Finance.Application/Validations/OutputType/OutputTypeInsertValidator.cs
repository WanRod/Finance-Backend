using FluentValidation;
using Project.Finance.Application.Commands.OutputType;

namespace Project.Finance.Application.Validations.OutputType;

public class OutputTypeInsertValidator : AbstractValidator<OutputTypeInsertRequest>
{
    public OutputTypeInsertValidator()
    {
        RuleFor(validation => validation).Custom(OutputTypeInsertValidations);
    }

    private void OutputTypeInsertValidations(OutputTypeInsertRequest request, ValidationContext<OutputTypeInsertRequest> context)
    {
        request.Description = request.Description.Trim();

        if (string.IsNullOrEmpty(request.Description))
        {
            context.AddFailure("A descrição é obrigatória.");
        }
    }
}
