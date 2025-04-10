using System;
using R2ETien.EFCore.Application.DTOs.Project;
using R2ETien.EFCore.Domain.Entities;

namespace R2ETien.EFCore.Mapping;

public static class ProjectMapping
{
    public static ProjectDTO ToDto(this Project project)
    {
        return new ProjectDTO(project.Id, project.Name);
    }

    public static Project ToEntity(this CreateProjectDTO dto)
    {
        return new Project { Id = Guid.NewGuid(), Name = dto.Name };
    }
}
