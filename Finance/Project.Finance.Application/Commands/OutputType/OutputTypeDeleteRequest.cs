using MediatR;

namespace Project.Finance.Application.Commands.OutputType;

public class OutputTypeDeleteRequest(Guid id) : IRequest<OutputTypeResponse>
{
    public Guid Id { get; } = id;
}
