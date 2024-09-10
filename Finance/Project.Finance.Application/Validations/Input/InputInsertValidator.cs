using FluentValidation;
using Project.Finance.Application.Commands.Input;

namespace Project.Finance.Application.Validations.Input;

public class InputInsertValidator : AbstractValidator<InputInsertRequest>
{
    public InputInsertValidator()
    {
        RuleFor(validation => validation).Custom(InputInsertValidations);
    }

    private void InputInsertValidations(InputInsertRequest request, ValidationContext<InputInsertRequest> context)
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
    }
}
