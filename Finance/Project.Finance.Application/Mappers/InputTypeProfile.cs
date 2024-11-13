using AutoMapper;
using Project.Finance.Application.Commands.InputType;
using Project.Finance.Domain.Entites;

namespace Project.Finance.Application.Mappers;

public class InputTypeProfile : Profile
{
    public InputTypeProfile()
    {
        CreateMap<InputTypeInsertRequest, InputType>();
        CreateMap<InputTypeUpdateRequest, InputType>();
        CreateMap<InputType, InputTypeResponse>();
    }
}
