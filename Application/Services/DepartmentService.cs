using System;
using R2ETien.EFCore.Application.Common.Constants;
using R2ETien.EFCore.Application.DTOs.Department;
using R2ETien.EFCore.Application.Interfaces;
using R2ETien.EFCore.Infrastructure.Repositories;
using R2ETien.EFCore.Mapping;

namespace R2ETien.EFCore.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;

    public DepartmentService(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CreateDepartmentDTO dto)
    {
        await _repository.AddAsync(dto.ToEntity());
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var department = await _repository.GetByIdAsync(id);
        if (department == null)
            throw new KeyNotFoundException(ErrorMessages.NotFound);
        _repository.Delete(department);
        await _repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<DepartmentDTO>> GetAllAsync()
    {
        var departments = await _repository.GetAllAsync();
        return departments.Select(d => d.ToDTO());
    }

    public async Task<DepartmentWithEmployeeDTO> GetByIdAsync(Guid id)
    {
        var department = await _repository.GetByIdAsync(id);
        return department == null
            ? throw new KeyNotFoundException(ErrorMessages.NotFound)
            : department.ToDTOWithEmployees();
    }

    public async Task UpdateAsync(Guid id, UpdateDepartmentDTO dto)
    {
        var department = await _repository.GetByIdAsync(id);
        if (department == null)
        {
            throw new KeyNotFoundException(ErrorMessages.NotFound);
        }
        department.Name = dto.Name;
        _repository.Update(department);
        await _repository.SaveChangesAsync();
    }
}
