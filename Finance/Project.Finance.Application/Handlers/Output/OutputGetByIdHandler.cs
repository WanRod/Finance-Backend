using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.Output;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.Output;

public class OutputGetByIdHandler(IOutputService service, IMapper mapper) : IRequestHandler<OutputGetByIdRequest, OutputResponse>
{
    public async Task<OutputResponse> Handle(OutputGetByIdRequest request, CancellationToken cancellationToken)
    {
        var output = await service.GetById(request.Id);
        return mapper.Map<OutputResponse>(output);
    }
}
