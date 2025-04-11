using System;
using R2ETien.EFCore.Application.DTOs.Employee;

namespace R2ETien.EFCore.Application.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDTO>> GetAllAsync();
    Task<IEnumerable<EmployeeWithProjectsDTO>> GetAllWithProjectsAsync();
    Task<IEnumerable<EmployeeWithProjectsDTO>> GetAllWithSalaryLargerThan100();
    Task<EmployeeDTO?> GetByIdAsync(Guid id);
    Task CreateAsync(CreateEmployeeDTO dto);
    Task UpdateAsync(Guid id, UpdateEmployeeDTO dto);
    Task DeleteAsync(Guid id);

    Task<IEnumerable<EmployeeWithProjectsDTO>> GetAllWithProjectsRawSqlAsync();

    Task<IEnumerable<EmployeeWithProjectsDTO>> GetEmployeesWithSalaryGreaterThan100RawSql();

    Task<IEnumerable<EmployeeWithProjectsDTO>> GetAllAsyncRawSql();
}
