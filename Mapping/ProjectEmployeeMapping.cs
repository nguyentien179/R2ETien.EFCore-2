using System;
using R2ETien.EFCore.Application.DTOs.ProjectEmployee;
using R2ETien.EFCore.Domain.Entities;

namespace R2ETien.EFCore.Mapping;

public static class ProjectEmployeeMapping
{
    public static ProjectEmployeeDTO ToDto(this ProjectEmployee entity)
    {
        return new ProjectEmployeeDTO(entity.ProjectId, entity.EmployeeId, entity.Enable);
    }

    public static ProjectEmployee ToEntity(this CreateProjectEmployeeDTO dto)
    {
        return new ProjectEmployee
        {
            ProjectId = dto.ProjectId,
            EmployeeId = dto.EmployeeId,
            Enable = dto.Enable,
        };
    }

    public static void UpdateFromDto(this ProjectEmployee entity, UpdateProjectEmployeDTO dto)
    {
        entity.Enable = dto.Enable;
    }
}
