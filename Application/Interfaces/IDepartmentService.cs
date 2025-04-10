using System;
using R2ETien.EFCore.Application.DTOs.Department;

namespace R2ETien.EFCore.Application.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDTO>> GetAllAsync();
    Task<DepartmentWithEmployeeDTO> GetByIdAsync(Guid id);
    Task CreateAsync(CreateDepartmentDTO dto);
    Task UpdateAsync(Guid id, UpdateDepartmentDTO dto);
    Task DeleteAsync(Guid id);
}
