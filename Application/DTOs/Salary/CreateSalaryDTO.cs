namespace R2ETien.EFCore.Application.DTOs.Salary;

public record class CreateSalaryDTO(Guid EmployeeId, decimal SalaryAmount);
