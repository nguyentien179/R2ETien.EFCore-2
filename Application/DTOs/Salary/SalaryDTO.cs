namespace R2ETien.EFCore.Application.DTOs.Salary;

public record class SalaryDTO(Guid Id, Guid EmployeeId, decimal SalaryAmount);
