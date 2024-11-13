using MediatR;

namespace Project.Finance.Application.Commands.InputType;

public class InputTypeInsertRequest : IRequest
{
    public required string Description { get; set; }
}
