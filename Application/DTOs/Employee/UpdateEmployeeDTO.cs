namespace R2ETien.EFCore.Application.DTOs.Employee;

public record class UpdateEmployeeDTO(string Name, DateOnly JoinedDate, Guid DepartmentId);
