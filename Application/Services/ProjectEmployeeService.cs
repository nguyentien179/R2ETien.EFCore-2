using System;
using R2ETien.EFCore.Application.Common.Constants;
using R2ETien.EFCore.Application.DTOs.ProjectEmployee;
using R2ETien.EFCore.Application.Interfaces;
using R2ETien.EFCore.Infrastructure.Repositories;
using R2ETien.EFCore.Mapping;

namespace R2ETien.EFCore.Application.Services;

public class ProjectEmployeeService : IProjectEmployeeService
{
    private readonly IProjectEmployeeRepository _repository;

    public ProjectEmployeeService(IProjectEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task AssignAsync(CreateProjectEmployeeDTO dto)
    {
        await _repository.AddAsync(dto.ToEntity());
        await _repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProjectEmployeeDTO>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(pe => pe.ToDto());
    }

    public async Task<ProjectEmployeeDTO?> GetByIdsAsync(Guid projectId, Guid employeeId)
    {
        var entity = await _repository.GetByIdsAsync(projectId, employeeId);
        if (entity == null)
        {
            throw new KeyNotFoundException(ErrorMessages.NotFound);
        }
        return entity.ToDto();
    }

    public async Task RemoveAsync(Guid projectId, Guid employeeId)
    {
        var entity = await _repository.GetByIdsAsync(projectId, employeeId);
        if (entity == null)
        {
            throw new KeyNotFoundException(ErrorMessages.NotFound);
        }
        _repository.Delete(entity);
        await _repository.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid projectId, Guid employeeId, UpdateProjectEmployeDTO dto)
    {
        var entity = await _repository.GetByIdsAsync(projectId, employeeId);
        if (entity == null)
        {
            throw new KeyNotFoundException(ErrorMessages.NotFound);
        }
        entity.UpdateFromDto(dto);
        _repository.Update(entity);
        await _repository.SaveChangesAsync();
    }
}
