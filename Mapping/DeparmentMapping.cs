using System;
using R2ETien.EFCore.Application.DTOs.Department;
using R2ETien.EFCore.Application.DTOs.Employee;
using R2ETien.EFCore.Domain.Entities;

namespace R2ETien.EFCore.Mapping;

public static class DeparmentMapping
{
    public static Department ToEntity(this CreateDepartmentDTO dto)
    {
        return new Department { Id = Guid.NewGuid(), Name = dto.Name };
    }

    public static Department ToEntity(this UpdateDepartmentDTO dto)
    {
        return new Department { Name = dto.Name };
    }

    public static DepartmentDTO ToDTO(this Department department)
    {
        return new DepartmentDTO(department.Id, department.Name);
    }

    public static DepartmentWithEmployeeDTO ToDTOWithEmployees(this Department department)
    {
        return new DepartmentWithEmployeeDTO(
            department.Id,
            department.Name,
            department.Employees.Select(e => e.ToDto())
        );
    }
}
