using System;
using FluentValidation;
using R2ETien.EFCore.Application.DTOs.Salary;
using R2ETien.EFCore.Infrastructure.Repositories;

namespace R2ETien.EFCore.Application.DTOs.SalaryValidation;

public class CreateSalaryValidatorDTO : AbstractValidator<CreateSalaryDTO>
{
    public CreateSalaryValidatorDTO(IEmployeeRepository employeeRepository)
    {
        RuleFor(x => x.SalaryAmount).NotEmpty().WithMessage("Amount of salary can not be empty");
        RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .WithMessage("Employee ID is required")
            .MustAsync(async (id, _) => await employeeRepository.ExistsAsync(id))
            .WithMessage("Employee does not exist");
    }
}
