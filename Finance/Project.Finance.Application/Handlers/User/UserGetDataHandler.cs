using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.User;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.User;

public class UserGetDataHandler(IUserService service, IMapper mapper) : IRequestHandler<UserGetDataRequest, UserResponse>
{
    public async Task<UserResponse> Handle(UserGetDataRequest request, CancellationToken cancellationToken)
    {
        var user = await service.GetData(request.Id);
        return mapper.Map<UserResponse>(user);
    }
}
