namespace R2ETien.EFCore.Application.DTOs.Employee;

public record class CreateEmployeeDTO(string Name, DateOnly JoinedDate, Guid DepartmentId);
