using AutoMapper;
using Project.Finance.Application.Commands.Dashboard;
using Project.Finance.Domain.Dtos;

namespace Project.Finance.Application.Mappers;

public class DashboardProfile : Profile
{
    public DashboardProfile()
    {
        CreateMap<Dashboard, DashboardResponse>();
        CreateMap<MonthlyDashboard, MonthlyDashboardResponse>();
        CreateMap<DashboardInputType, DashboardInputTypeResponse>();
        CreateMap<DashboardOutputType, DashboardOutputTypeResponse>();
    }
}
