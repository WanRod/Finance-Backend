using MediatR;

namespace Project.Finance.Application.Commands.OutputType;

public class OutputTypeInsertRequest : IRequest
{
    public required string Description { get; set; }
}
