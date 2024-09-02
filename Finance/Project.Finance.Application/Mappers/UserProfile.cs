using AutoMapper;
using Project.Finance.Application.Commands.User;

namespace Project.Finance.Application.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserInsertRequest, Domain.Entites.User>();
        CreateMap<UserUpdateRequest, Domain.Entites.User>();
        CreateMap<Domain.Entites.User, UserResponse>();
    }
}
