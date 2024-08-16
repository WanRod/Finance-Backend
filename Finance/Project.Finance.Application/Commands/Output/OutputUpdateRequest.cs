using MediatR;

namespace Project.Finance.Application.Commands.Output;

public class OutputUpdateRequest : IRequest
{
    public Guid Id { get; set; }

    public Guid OutputTypeId { get; set; }

    public required string Description { get; set; }

    public decimal Value { get; set; }

    public DateOnly Date { get; set; }
}
