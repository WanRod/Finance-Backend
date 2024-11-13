using FluentValidation;
using Project.Finance.Application.Commands.User;

namespace Project.Finance.Application.Validations.User;

public class UserUpdateValidator : AbstractValidator<UserUpdateRequest>
{
    public UserUpdateValidator()
    {
        RuleFor(validation => validation).Custom(UserUpdateValidations);
    }

    private void UserUpdateValidations(UserUpdateRequest request, ValidationContext<UserUpdateRequest> context)
    {
        if (!string.IsNullOrEmpty(request.Name))
        {
            request.Name = request.Name.Trim();

            if (request.Name.Length > 50)
            {
                context.AddFailure("O comprimento máximo do nome é de 50 caracteres.");
            }
        }

        if (!string.IsNullOrEmpty(request.Password))
        {
            request.Password = request.Password.Trim();

            if (request.Password.Length > 50)
            {
                context.AddFailure("O comprimento máximo da senha é de 50 caracteres.");
            }
        }
    }
}
