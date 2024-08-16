using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.User;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.User;

public class UserGetByIdHandler(IUserService service, IMapper mapper) : IRequestHandler<UserGetByIdRequest, UserResponse>
{
    public async Task<UserResponse> Handle(UserGetByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await service.GetById(request.Id);
        return mapper.Map<UserResponse>(user);
    }
}
