﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Finance.Domain.Interfaces;
using Project.Finance.Domain.Interfaces.Repositories;
using Project.Finance.Domain.Interfaces.Services;
using Project.Finance.Domain.Services;
using Project.Finance.Infrastructure;
using Project.Finance.Infrastructure.Repositories;

namespace Project.Finance.Application;

public static class DependencyInjection
{
    public static IServiceCollection FinanceDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IDashboardRepository, DashboardRepository>();
        services.AddScoped<IDashboardService, DashboardService>();

        services.AddScoped<IInputTypeRepository, InputTypeRepository>();
        services.AddScoped<IInputTypeService, InputTypeService>();

        services.AddScoped<IInputRepository, InputRepository>();
        services.AddScoped<IInputService, InputService>();

        services.AddScoped<IOutputTypeRepository, OutputTypeRepository>();
        services.AddScoped<IOutputTypeService, OutputTypeService>();

        services.AddScoped<IOutputRepository, OutputRepository>();
        services.AddScoped<IOutputService, OutputService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddScoped<IUserContext, UserContext>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();

        return services;
    }
}
