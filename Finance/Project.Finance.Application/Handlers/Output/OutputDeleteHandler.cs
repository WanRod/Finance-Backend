using MediatR;
using Project.Finance.Application.Commands.Output;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Output;

public class OutputDeleteHandler(IOutputService service) : IRequestHandler<OutputDeleteRequest>
{
    public async Task Handle(OutputDeleteRequest request, CancellationToken cancellationToken)
    {
        await service.Delete(request.Id);
    }
}
