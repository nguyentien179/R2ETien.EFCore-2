using System;
using FluentValidation;
using R2ETien.EFCore.Application.DTOs.Employee;
using R2ETien.EFCore.Infrastructure.Repositories;

namespace R2ETien.EFCore.Application.DTOs.EmployeeValidation;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDTO>
{
    public CreateEmployeeValidator(IDepartmentRepository departmentRepository)
    {
        RuleFor(e => e.Name)
            .NotEmpty()
            .WithMessage("Employee name is required.")
            .MaximumLength(100)
            .WithMessage("Employee name must be at most 100 characters.");

        RuleFor(e => e.JoinedDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Joined date cannot be in the future.");

        RuleFor(e => e.DepartmentId)
            .NotEmpty()
            .WithMessage("Department ID is required.")
            .MustAsync(async (id, _) => await departmentRepository.ExistsAsync(id))
            .WithMessage("DepartmentId is invalid or does not exist.");
        ;
    }
}
