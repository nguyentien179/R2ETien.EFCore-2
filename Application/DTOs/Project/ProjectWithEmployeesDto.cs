using R2ETien.EFCore.Application.DTOs.Employee;

namespace R2ETien.EFCore.Application.DTOs.Project;

public record class ProjectWithEmployeesDto(Guid Id, string Name, List<EmployeeDTO> Employees);
