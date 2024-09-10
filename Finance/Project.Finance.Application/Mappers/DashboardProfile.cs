using AutoMapper;
using Project.Finance.Application.Commands.Dashboard;
using Project.Finance.Domain.Data;

namespace Project.Finance.Application.Mappers;

public class DashboardProfile : Profile
{
    public DashboardProfile()
    {
        CreateMap<Dashboard, DashboardResponse>();
        CreateMap<MonthlyDashboard, MonthlyDashboardResponse>();
        CreateMap<DashboardOutputTypes, DashboardOutputTypesResponse>();
    }
}
