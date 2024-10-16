using AutoMapper;
using Project.Finance.Application.Commands.User;

namespace Project.Finance.Application.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserInsertRequest, Domain.Entites.User>();
        CreateMap<UserUpdateRequest, Domain.Entites.User>();
        CreateMap<Domain.Entites.User, UserResponse>()
            .ForMember(dest => dest.CpfCnpj, opt => opt.MapFrom(e => (e.CpfCnpj.Length == 11) ? Convert.ToUInt64(e.CpfCnpj).ToString(@"000\.000\.000\-00") : Convert.ToUInt64(e.CpfCnpj).ToString(@"00\.000\.000\/0000\-00")));
    }
}
