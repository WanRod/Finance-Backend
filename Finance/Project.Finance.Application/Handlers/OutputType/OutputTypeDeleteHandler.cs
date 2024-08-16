using MediatR;
using Project.Finance.Application.Commands.OutputType;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.OutputType;

public class OutputTypeDeleteHandler(IOutputTypeService service) : IRequestHandler<OutputTypeDeleteRequest>
{
    public async Task Handle(OutputTypeDeleteRequest request, CancellationToken cancellationToken)
    {
        await service.Delete(request.Id);
    }
}
