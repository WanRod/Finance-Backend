using AutoMapper;
using MediatR;
using Project.Finance.Application.Commands.User;
using Project.Finance.Domain.Interfaces.Services;

namespace Project.Finance.Application.Handlers.User;

public class UserUpdateHandler(IUserService service, IMapper mapper) : IRequestHandler<UserUpdateRequest>
{
    public async Task Handle(UserUpdateRequest request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<Domain.Entites.User>(request);
        user.CpfCnpj = (await service.GetById(request.Id))!.CpfCnpj;
        await service.Update(user.Id, user);
    }
}
