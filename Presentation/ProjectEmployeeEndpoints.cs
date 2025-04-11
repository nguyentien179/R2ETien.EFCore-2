using System;
using Microsoft.AspNetCore.Mvc;
using R2ETien.EFCore.Application.Common.Filter;
using R2ETien.EFCore.Application.DTOs.ProjectEmployee;
using R2ETien.EFCore.Application.DTOs.ProjectEmployeeValidation;
using R2ETien.EFCore.Application.Interfaces;

namespace R2ETien.EFCore.Presentation;

public static class ProjectEmployeeEndpoints
{
    public static void MapProjectEmployeeEndpoints(this IEndpointRouteBuilder group)
    {
        var projectEmployeeGroup = group.MapGroup("/project-employees").WithTags("ProjectEmployee");

        projectEmployeeGroup.MapGet("/", GetAllAsync);
        projectEmployeeGroup.MapGet("/{projectId:guid}/{employeeId:guid}", GetByIdsAsync);
        projectEmployeeGroup
            .MapPost("/", AssignAsync)
            .AddEndpointFilter<ValidationFilter<CreateProjectEmployeeDTO>>();
        projectEmployeeGroup
            .MapPut("/{projectId:guid}/{employeeId:guid}", UpdateAsync)
            .AddEndpointFilter<ValidationFilter<UpdateProjectEmployeDTO>>();
        ;
        projectEmployeeGroup.MapDelete("/{projectId:guid}/{employeeId:guid}", RemoveAsync);
    }

    private static async Task<IResult> GetAllAsync([FromServices] IProjectEmployeeService service)
    {
        var result = await service.GetAllAsync();
        return Results.Ok(result);
    }

    private static async Task<IResult> GetByIdsAsync(
        Guid projectId,
        Guid employeeId,
        [FromServices] IProjectEmployeeService service
    )
    {
        var result = await service.GetByIdsAsync(projectId, employeeId);
        return result is not null ? Results.Ok(result) : Results.NotFound();
    }

    private static async Task<IResult> AssignAsync(
        [FromBody] CreateProjectEmployeeDTO dto,
        [FromServices] IProjectEmployeeService service
    )
    {
        await service.AssignAsync(dto);
        return Results.Created($"/api/project-employees/{dto.ProjectId}/{dto.EmployeeId}", dto);
    }

    private static async Task<IResult> UpdateAsync(
        Guid projectId,
        Guid employeeId,
        [FromBody] UpdateProjectEmployeDTO dto,
        [FromServices] IProjectEmployeeService service
    )
    {
        await service.UpdateAsync(projectId, employeeId, dto);
        return Results.NoContent();
    }

    private static async Task<IResult> RemoveAsync(
        Guid projectId,
        Guid employeeId,
        [FromServices] IProjectEmployeeService service
    )
    {
        await service.RemoveAsync(projectId, employeeId);
        return Results.NoContent();
    }
}
