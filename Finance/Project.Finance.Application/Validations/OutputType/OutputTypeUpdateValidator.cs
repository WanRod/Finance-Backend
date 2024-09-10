using FluentValidation;
using Project.Finance.Application.Commands.OutputType;

namespace Project.Finance.Application.Validations.OutputType;

public class OutputTypeUpdateValidator : AbstractValidator<OutputTypeUpdateRequest>
{
    public OutputTypeUpdateValidator()
    {
        RuleFor(validation => validation).Custom(OutputTypeUpdateValidations);
    }

    private void OutputTypeUpdateValidations(OutputTypeUpdateRequest request, ValidationContext<OutputTypeUpdateRequest> context)
    {
        request.Description = request.Description.Trim();

        if (string.IsNullOrEmpty(request.Description))
        {
            context.AddFailure("A descrição é obrigatória.");
        }
    }
}
