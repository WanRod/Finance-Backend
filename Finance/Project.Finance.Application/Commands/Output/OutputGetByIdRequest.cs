using MediatR;

namespace Project.Finance.Application.Commands.Output;

public class OutputGetByIdRequest(Guid id) : IRequest<OutputResponse>
{
    public Guid Id { get; } = id;
}
