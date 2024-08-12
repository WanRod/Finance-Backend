using Microsoft.Extensions.DependencyInjection;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;
using Project.Finance.Domain.Services;
using Project.Finance.Infrastructure.Repositories;

namespace Project.Finance.Application;

public static class DependencyInjection
{
    public static IServiceCollection FinanceDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IInputRepository, InputRepository>();
        services.AddScoped<IInputService, InputService>();

        services.AddScoped<IOutputTypeRepository, OutputTypeRepository>();
        services.AddScoped<IOutputTypeService, OutputTypeService>();

        services.AddScoped<IOutputRepository, OutputRepository>();
        services.AddScoped<IOutputService, OutputService>();

        services.AddScoped<IDashboardRepository, DashboardRepository>();
        services.AddScoped<IDashboardService, DashboardService>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        return services;
    }
}
