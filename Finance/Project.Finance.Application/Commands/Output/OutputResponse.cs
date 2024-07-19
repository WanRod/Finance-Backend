using Project.Finance.Application.Commands.OutputType;

namespace Project.Finance.Application.Commands.Output;

public class OutputResponse
{
    public Guid Id { get; set; }

    public required OutputTypeResponse OutputType { get; set; }

    public required string Description { get; set; }

    public decimal Value { get; set; }

    public DateOnly Date { get; set; }
}
