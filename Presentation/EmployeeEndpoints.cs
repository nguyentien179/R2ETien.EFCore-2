using System;
using Microsoft.AspNetCore.Mvc;
using R2ETien.EFCore.Application.Common.Filter;
using R2ETien.EFCore.Application.DTOs.Employee;
using R2ETien.EFCore.Application.Interfaces;

namespace R2ETien.EFCore.Presentation;

public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints(this IEndpointRouteBuilder group)
    {
        var employeeGroup = group.MapGroup("/employees").WithTags("Employees");

        employeeGroup.MapGet("/", GetAllAsync);
        employeeGroup.MapGet("/withProjects", GetAllWithProjectsAsync);
        employeeGroup.MapGet("/salaryLargerThan100", GetAllWithSalaryLargerThan100);
        employeeGroup.MapGet("/getAllRawSQL", GetAllAsyncRawSQL);
        employeeGroup.MapGet("/withProjectsSQL", GetAllWithProjectsAsyncRawSQL);
        employeeGroup.MapGet("/salaryLargerThan100SQL", GetAllWithSalaryLargerThan100RawSQL);
        employeeGroup.MapGet("/{id:guid}", GetByIdAsync);
        employeeGroup
            .MapPost("/", CreateAsync)
            .AddEndpointFilter<ValidationFilter<CreateEmployeeDTO>>();
        employeeGroup
            .MapPut("/{id:guid}", UpdateAsync)
            .AddEndpointFilter<ValidationFilter<UpdateEmployeeDTO>>();
        employeeGroup.MapDelete("/{id:guid}", DeleteAsync);
    }

    private static async Task<IResult> GetAllAsyncRawSQL([FromServices] IEmployeeService service)
    {
        var employees = await service.GetAllAsyncRawSql();
        return Results.Ok(employees);
    }

    private static async Task<IResult> GetAllWithSalaryLargerThan100RawSQL(
        [FromServices] IEmployeeService service
    )
    {
        var employees = await service.GetAllWithSalaryLargerThan100();
        return Results.Ok(employees);
    }

    private static async Task<IResult> GetAllWithProjectsAsyncRawSQL(
        [FromServices] IEmployeeService service
    )
    {
        var employees = await service.GetAllWithProjectsRawSqlAsync();
        return Results.Ok(employees);
    }

    private static async Task<IResult> GetAllWithSalaryLargerThan100(
        [FromServices] IEmployeeService service
    )
    {
        var employees = await service.GetAllWithSalaryLargerThan100();
        return Results.Ok(employees);
    }

    private static async Task<IResult> GetAllWithProjectsAsync(
        [FromServices] IEmployeeService service
    )
    {
        var employees = await service.GetAllWithProjectsAsync();
        return Results.Ok(employees);
    }

    private static async Task<IResult> GetAllAsync([FromServices] IEmployeeService service)
    {
        var employees = await service.GetAllAsync();
        return Results.Ok(employees);
    }

    private static async Task<IResult> GetByIdAsync(
        Guid id,
        [FromServices] IEmployeeService service
    )
    {
        var employee = await service.GetByIdAsync(id);
        return employee is not null ? Results.Ok(employee) : Results.NotFound();
    }

    private static async Task<IResult> CreateAsync(
        [FromBody] CreateEmployeeDTO dto,
        [FromServices] IEmployeeService service
    )
    {
        await service.CreateAsync(dto);
        return Results.Created("/api/employees", dto);
    }

    private static async Task<IResult> UpdateAsync(
        Guid id,
        [FromBody] UpdateEmployeeDTO dto,
        [FromServices] IEmployeeService service
    )
    {
        await service.UpdateAsync(id, dto);
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteAsync(Guid id, [FromServices] IEmployeeService service)
    {
        await service.DeleteAsync(id);
        return Results.NoContent();
    }
}
