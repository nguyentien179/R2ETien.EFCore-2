using System;
using Microsoft.AspNetCore.Mvc;
using R2ETien.EFCore.Application.DTOs.Employee;
using R2ETien.EFCore.Application.Interfaces;

namespace R2ETien.EFCore.Presentation;

public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints(this IEndpointRouteBuilder group)
    {
        var employeeGroup = group.MapGroup("/employees").WithTags("Employees");

        employeeGroup.MapGet("/", GetAllAsync);
        employeeGroup.MapGet("/{id:guid}", GetByIdAsync);
        employeeGroup.MapPost("/", CreateAsync);
        employeeGroup.MapPut("/{id:guid}", UpdateAsync);
        employeeGroup.MapDelete("/{id:guid}", DeleteAsync);
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
