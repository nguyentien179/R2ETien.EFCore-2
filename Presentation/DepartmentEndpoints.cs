using System;
using Microsoft.AspNetCore.Mvc;
using R2ETien.EFCore.Application.DTOs.Department;
using R2ETien.EFCore.Application.DTOs.DepartmentValidation;
using R2ETien.EFCore.Application.Interfaces;

namespace R2ETien.EFCore.Presentation;

public static class DepartmentEndpoints
{
    public static void MapDepartmentEndpoints(this IEndpointRouteBuilder group)
    {
        var departmentGroup = group.MapGroup("/departments").WithTags("Department");
        departmentGroup.MapGet("/", GetAllAsync);
        departmentGroup.MapGet("/{id:guid}", GetByIdAsync);
        departmentGroup.MapPost("/", CreateAsync);
        departmentGroup.MapPut("/{id:guid}", UpdateAsync);
        departmentGroup.MapDelete("/{id:guid}", DeleteAsync);
    }

    private static async Task<IResult> GetAllAsync([FromServices] IDepartmentService service)
    {
        var departments = await service.GetAllAsync();
        return Results.Ok(departments);
    }

    private static async Task<IResult> GetByIdAsync(
        Guid id,
        [FromServices] IDepartmentService service
    )
    {
        var department = await service.GetByIdAsync(id);
        return department is not null ? Results.Ok(department) : Results.NotFound();
    }

    private static async Task<IResult> CreateAsync(
        [FromBody] CreateDepartmentDTO dto,
        [FromServices] IDepartmentService service
    )
    {
        await service.CreateAsync(dto);
        return Results.Created("/departments", dto);
    }

    private static async Task<IResult> UpdateAsync(
        Guid id,
        [FromBody] UpdateDepartmentDTO dto,
        [FromServices] IDepartmentService service
    )
    {
        await service.UpdateAsync(id, dto);
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteAsync(
        Guid id,
        [FromServices] IDepartmentService service
    )
    {
        await service.DeleteAsync(id);
        return Results.NoContent();
    }
}
