using System;
using R2ETien.EFCore.Application.DTOs.Employee;
using R2ETien.EFCore.Application.DTOs.Project;
using R2ETien.EFCore.Domain.Entities;

namespace R2ETien.EFCore.Mapping;

public static class EmployeeMapping
{
    public static Employee ToEntity(this CreateEmployeeDTO dto)
    {
        return new Employee
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            JoinedDate = dto.JoinedDate,
            DepartmentId = dto.DepartmentId,
        };
    }

    public static Employee ToEntity(this UpdateEmployeeDTO dto, Guid id)
    {
        return new Employee
        {
            Id = id,
            Name = dto.Name,
            JoinedDate = dto.JoinedDate,
            DepartmentId = dto.DepartmentId,
        };
    }

    public static EmployeeDTO ToDto(this Employee employee)
    {
        return new EmployeeDTO(
            employee.Id,
            employee.Name,
            employee.JoinedDate,
            employee.DepartmentId,
            employee.Department?.Name ?? "N/A",
            employee.Salary?.Amount
        );
    }

    public static EmployeeWithProjectsDTO ToDtoWithProjects(this Employee employee)
    {
        var projects =
            employee
                .ProjectEmployees?.Where(pe => pe.Project != null)
                .Select(pe => pe.Project!.ToDto())
                .ToList() ?? new();

        return new EmployeeWithProjectsDTO(
            employee.Id,
            employee.Name,
            employee.JoinedDate,
            employee.DepartmentId,
            employee.Department?.Name ?? string.Empty,
            employee.Salary?.Amount,
            projects
        );
    }
}
