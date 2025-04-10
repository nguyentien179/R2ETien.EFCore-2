using System;
using R2ETien.EFCore.Application.Common.Constants;
using R2ETien.EFCore.Application.DTOs.Project;
using R2ETien.EFCore.Application.Interfaces;
using R2ETien.EFCore.Infrastructure.Repositories;
using R2ETien.EFCore.Mapping;

namespace R2ETien.EFCore.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CreateProjectDTO dto)
    {
        await _repository.AddAsync(dto.ToEntity());
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var project = await _repository.GetByIdAsync(id);
        if (project == null)
            throw new KeyNotFoundException(ErrorMessages.NotFound);
        _repository.Delete(project);
        await _repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
    {
        var projects = await _repository.GetAllAsync();
        return projects.Select(e => e.ToDto());
    }

    public async Task<ProjectDTO?> GetByIdAsync(Guid id)
    {
        var project = await _repository.GetByIdAsync(id);
        return project == null
            ? throw new KeyNotFoundException(ErrorMessages.NotFound)
            : project.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateProjectDTO dto)
    {
        var project = await _repository.GetByIdAsync(id);
        if (project == null)
        {
            throw new KeyNotFoundException(ErrorMessages.NotFound);
        }
        project.Name = dto.Name;
        _repository.Update(project);
        await _repository.SaveChangesAsync();
    }
}
