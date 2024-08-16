using MediatR;

namespace Project.Finance.Application.Commands.OutputType;

public class OutputTypeDeleteRequest(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}
