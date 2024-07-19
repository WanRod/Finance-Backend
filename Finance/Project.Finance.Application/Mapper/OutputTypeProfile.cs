using AutoMapper;
using Project.Finance.Application.Commands.OutputType;
using Project.Finance.Domain.Entites;

namespace Project.Finance.Application.Mapper;

public class OutputTypeProfile : Profile
{
    public OutputTypeProfile()
    {
        CreateMap<OutputTypeInsertRequest, OutputType>();
        CreateMap<OutputTypeUpdateRequest, OutputType>();
        CreateMap<OutputType, OutputTypeResponse>();
    }
}
