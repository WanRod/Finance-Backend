using MediatR;

namespace Project.Finance.Application.Commands.InputType;

public class InputTypeGetAllRequest : IRequest<List<InputTypeResponse>>
{
    public int? Quantity { get; set; }
}
