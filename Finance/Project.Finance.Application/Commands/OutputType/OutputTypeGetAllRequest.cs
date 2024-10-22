using MediatR;

namespace Project.Finance.Application.Commands.OutputType;

public class OutputTypeGetAllRequest : IRequest<List<OutputTypeResponse>>
{
    public int? Quantity { get; set; }
}
