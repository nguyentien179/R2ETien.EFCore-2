namespace R2ETien.EFCore.Application.DTOs.Salary;

public record class UpdateSalaryDTO(Guid EmployeeId, decimal SalaryAmount);
