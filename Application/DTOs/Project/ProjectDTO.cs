using R2ETien.EFCore.Application.DTOs.Employee;

namespace R2ETien.EFCore.Application.DTOs.Project;

public record class ProjectDTO(Guid Id, string Name, IEnumerable<EmployeeDTO> Employees);
