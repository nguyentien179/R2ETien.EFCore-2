using R2ETien.EFCore.Application.DTOs.Project;

namespace R2ETien.EFCore.Application.DTOs.Employee;

public record class EmployeeWithProjectsDTO(
    Guid Id,
    string Name,
    DateOnly JoinedDate,
    Guid DepartmentId,
    string DepartmentName,
    decimal? SalaryAmount,
    List<ProjectDTO> Projects
);
