using System;
using R2ETien.EFCore.Application.DTOs.Salary;

namespace R2ETien.EFCore.Application.Interfaces;

public interface ISalaryService
{
    Task<SalaryDTO?> GetByEmployeeIdAsync(Guid employeeId);
    Task CreateAsync(CreateSalaryDTO dto);
    Task UpdateAsync(Guid employeeId, UpdateSalaryDTO dto);
    Task DeleteAsync(Guid employeeId);
}
