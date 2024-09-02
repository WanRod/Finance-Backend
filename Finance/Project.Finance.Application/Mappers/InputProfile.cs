using AutoMapper;
using Project.Finance.Application.Commands.Input;
using Project.Finance.Domain.Entites;

namespace Project.Finance.Application.Mappers;

public class InputProfile : Profile
{
    public InputProfile()
    {
        CreateMap<InputInsertRequest, Input>();
        CreateMap<InputUpdateRequest, Input>();
        CreateMap<Input, InputResponse>();
    }
}
