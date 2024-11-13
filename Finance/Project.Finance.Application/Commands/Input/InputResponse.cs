using Project.Finance.Application.Commands.InputType;

namespace Project.Finance.Application.Commands.Input;

public class InputResponse
{
    public Guid Id { get; set; }

    public required InputTypeResponse InputType { get; set; }

    public required string Description { get; set; }

    public decimal Value { get; set; }

    public DateOnly Date { get; set; }
}
