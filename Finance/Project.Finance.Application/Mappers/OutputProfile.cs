using AutoMapper;
using Project.Finance.Application.Commands.Output;
using Project.Finance.Domain.Entites;

namespace Project.Finance.Application.Mappers;

public class OutputProfile : Profile
{
    public OutputProfile()
    {
        CreateMap<OutputInsertRequest, Output>();
        CreateMap<OutputUpdateRequest, Output>();
        CreateMap<Output, OutputResponse>();
    }
}
