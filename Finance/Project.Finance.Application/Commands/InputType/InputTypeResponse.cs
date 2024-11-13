namespace Project.Finance.Application.Commands.InputType;

public class InputTypeResponse
{
    public Guid Id { get; set; }

    public required string Description { get; set; }

    public Guid CreatedBy { get; set; }
}
