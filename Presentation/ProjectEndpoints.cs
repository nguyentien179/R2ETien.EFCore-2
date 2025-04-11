using System;
using Microsoft.AspNetCore.Mvc;
using R2ETien.EFCore.Application.Common.Filter;
using R2ETien.EFCore.Application.DTOs.Project;
using R2ETien.EFCore.Application.Interfaces;

namespace R2ETien.EFCore.Presentation;

public static class ProjectEndpoints
{
    public static void MapProjectEndpoints(this IEndpointRouteBuilder group)
    {
        var projectGroup = group.MapGroup("/projects").WithTags("Projects");
        projectGroup.MapGet("/", GetAllAsync);
        projectGroup.MapGet("/{id:guid}", GetByIdAsync);
        projectGroup
            .MapPost("/", CreateAsync)
            .AddEndpointFilter<ValidationFilter<CreateProjectDTO>>();
        projectGroup
            .MapPut("/{id:guid}", UpdateAsync)
            .AddEndpointFilter<ValidationFilter<UpdateProjectDTO>>();
        projectGroup.MapDelete("/{id:guid}", DeleteAsync);
    }

    private static async Task<IResult> GetAllAsync([FromServices] IProjectService service)
    {
        var projects = await service.GetAllAsync();
        return Results.Ok(projects);
    }

    private static async Task<IResult> GetByIdAsync(Guid id, [FromServices] IProjectService service)
    {
        var project = await service.GetByIdAsync(id);
        return project is not null ? Results.Ok(project) : Results.NotFound();
    }

    private static async Task<IResult> CreateAsync(
        [FromBody] CreateProjectDTO dto,
        [FromServices] IProjectService service
    )
    {
        await service.CreateAsync(dto);
        return Results.Created("/api/projects", dto);
    }

    private static async Task<IResult> UpdateAsync(
        Guid id,
        [FromBody] UpdateProjectDTO dto,
        [FromServices] IProjectService service
    )
    {
        await service.UpdateAsync(id, dto);
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteAsync(Guid id, [FromServices] IProjectService service)
    {
        await service.DeleteAsync(id);
        return Results.NoContent();
    }
}
