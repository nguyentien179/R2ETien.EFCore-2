using System;
using R2ETien.EFCore.Application.DTOs.Employee;
using R2ETien.EFCore.Domain.Entities;

namespace R2ETien.EFCore.Infrastructure.Repositories;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<bool> ExistsAsync(Guid id);

    Task<IEnumerable<EmployeeWithProjectsDTO?>> GetAllWithProjectsAsync();

    Task<IEnumerable<EmployeeWithProjectsDTO>> GetEmployeeWithSalaryGreaterThan100();

    Task<IEnumerable<EmployeeWithProjectsDTO>> GetAllWithProjectsRawSqlAsync();

    Task<IEnumerable<EmployeeWithProjectsDTO>> GetEmployeesWithSalaryGreaterThan100RawSql();

    Task<IEnumerable<EmployeeWithProjectsDTO>> GetAllAsyncRawSql();
}
