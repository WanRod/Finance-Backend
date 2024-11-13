using MediatR;

namespace Project.Finance.Application.Commands.InputType;

public class InputTypeUpdateRequest : IRequest
{
    public Guid Id { get; set; }

    public required string Description { get; set; }
}
