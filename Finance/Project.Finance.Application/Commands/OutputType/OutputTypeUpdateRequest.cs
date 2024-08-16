using MediatR;

namespace Project.Finance.Application.Commands.OutputType;

public class OutputTypeUpdateRequest : IRequest
{
    public Guid Id { get; set; }

    public required string Description { get; set; }
}
