using System;
using R2ETien.EFCore.Application.Interfaces;
using R2ETien.EFCore.Application.Services;
using R2ETien.EFCore.Infrastructure.Repositories;
using R2ETien.EFCore.Infrastructure.Repositories.Interfaces;

namespace R2ETien.EFCore.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IDepartmentService, DepartmentService>();

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEmployeeService, EmployeeService>();

        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IProjectService, ProjectService>();

        services.AddScoped<ISalaryRepository, SalaryRepository>();
        services.AddScoped<ISalaryService, SalaryService>();

        services.AddScoped<IProjectEmployeeRepository, ProjectEmployeeRepository>();
        services.AddScoped<IProjectEmployeeService, ProjectEmployeeService>();

        return services;
    }
}
