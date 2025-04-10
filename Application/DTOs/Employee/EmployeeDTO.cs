namespace R2ETien.EFCore.Application.DTOs.Employee;

public record class EmployeeDTO(
    Guid Id,
    string Name,
    DateOnly JoinedDate,
    Guid DepartmentId,
    string DepartmentName,
    decimal? SalaryAmount
);
