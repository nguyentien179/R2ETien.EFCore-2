using System;
using R2ETien.EFCore.Application.DTOs.Employee;

namespace R2ETien.EFCore.Application.DTOs.Department;

public record class DepartmentWithEmployeeDTO(
    Guid Id,
    string Name,
    IEnumerable<EmployeeDTO> Employees
);
