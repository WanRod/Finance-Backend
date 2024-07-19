using MediatR;

namespace Project.Finance.Application.Commands.Input;

public class InputGetAllRequest : IRequest<List<InputResponse>>
{

}
