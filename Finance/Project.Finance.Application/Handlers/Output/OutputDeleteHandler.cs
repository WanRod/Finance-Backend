using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Output;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Output;

public class OutputDeleteHandler(IOutputService service, IMapper mapper) : IRequestHandler<OutputDeleteRequest, OutputResponse>
{
    public async Task<OutputResponse> Handle(OutputDeleteRequest request, CancellationToken cancellationToken)
    {
        var output = await service.Delete(request.Id);
        return mapper.Map<OutputResponse>(output);
    }
}
