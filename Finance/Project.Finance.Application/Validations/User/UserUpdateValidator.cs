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
        }

        if (!string.IsNullOrEmpty(request.Password))
        {
            request.Password = request.Password.Trim();
        }
    }
}
