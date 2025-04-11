using System;
using R2ETien.EFCore.Application.DTOs.Employee;
using R2ETien.EFCore.Application.DTOs.Project;
using R2ETien.EFCore.Domain.Entities;

namespace R2ETien.EFCore.Mapping;

public static class ProjectMapping
{
    public static ProjectDTO ToDto(this Project project)
    {
        var employees =
            project
                .ProjectEmployees?.Where(pe => pe.Employee != null)
                .Select(pe => pe.Employee!.ToDto())
                .ToList() ?? new();

        return new ProjectDTO(project.Id, project.Name, employees);
    }

    public static Project ToEntity(this CreateProjectDTO dto)
    {
        return new Project { Id = Guid.NewGuid(), Name = dto.Name };
    }
}
