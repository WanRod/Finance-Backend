using MediatR;

namespace Project.Finance.Application.Commands.OutputType;

public class OutputTypeInsertRequest : IRequest<OutputTypeResponse>
{
    public required string Description { get; set; }
}
