using System;
using R2ETien.EFCore.Application.DTOs.Project;

namespace R2ETien.EFCore.Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectDTO>> GetAllAsync();
    Task<ProjectDTO?> GetByIdAsync(Guid id);
    Task CreateAsync(CreateProjectDTO dto);
    Task UpdateAsync(Guid id, UpdateProjectDTO dto);
    Task DeleteAsync(Guid id);
}
