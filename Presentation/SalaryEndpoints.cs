using System;
using Microsoft.AspNetCore.Mvc;
using R2ETien.EFCore.Application.Common.Filter;
using R2ETien.EFCore.Application.DTOs.Salary;
using R2ETien.EFCore.Application.Interfaces;

namespace R2ETien.EFCore.Presentation;

public static class SalaryEndpoints
{
    public static void MapSalaryEndpoints(this IEndpointRouteBuilder group)
    {
        var salaryGroup = group.MapGroup("/salaries").WithTags("Salaries");

        salaryGroup.MapGet("/{employeeId:guid}", GetByEmployeeIdAsync);
        salaryGroup
            .MapPost("/", CreateAsync)
            .AddEndpointFilter<ValidationFilter<CreateSalaryDTO>>();
        salaryGroup
            .MapPut("/{employeeId:guid}", UpdateAsync)
            .AddEndpointFilter<ValidationFilter<UpdateSalaryDTO>>();
        salaryGroup.MapDelete("/{employeeId:guid}", DeleteAsync);
    }

    private static async Task<IResult> GetByEmployeeIdAsync(
        Guid employeeId,
        [FromServices] ISalaryService service
    )
    {
        var result = await service.GetByEmployeeIdAsync(employeeId);
        return result is not null ? Results.Ok(result) : Results.NotFound();
    }

    private static async Task<IResult> CreateAsync(
        [FromBody] CreateSalaryDTO dto,
        [FromServices] ISalaryService service
    )
    {
        await service.CreateAsync(dto);
        return Results.Created($"/api/salaries/{dto.EmployeeId}", dto);
    }

    private static async Task<IResult> UpdateAsync(
        Guid employeeId,
        [FromBody] UpdateSalaryDTO dto,
        [FromServices] ISalaryService service
    )
    {
        await service.UpdateAsync(employeeId, dto);
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteAsync(
        Guid employeeId,
        [FromServices] ISalaryService service
    )
    {
        await service.DeleteAsync(employeeId);
        return Results.NoContent();
    }
}
