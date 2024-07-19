using MediatR;

namespace Project.Finance.Application.Commands.Output;

public class OutputInsertRequest : IRequest<OutputResponse>
{
    public Guid OutputTypeId { get; set; }

    public required string Description { get; set; }

    public decimal Value { get; set; }

    public DateOnly Date { get; set; }
}
