using MediatR;

namespace Project.Finance.Application.Commands.Output;

public class OutputGetAllRequest : IRequest<List<OutputResponse>>
{
    public int? Quantity { get; set; }
}
