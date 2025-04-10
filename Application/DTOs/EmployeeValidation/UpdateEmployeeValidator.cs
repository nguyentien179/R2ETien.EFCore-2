using System;
using FluentValidation;
using R2ETien.EFCore.Application.DTOs.Employee;

namespace R2ETien.EFCore.Application.DTOs.EmployeeValidation;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDTO>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty()
            .WithMessage("Employee name is required.")
            .MaximumLength(100)
            .WithMessage("Employee name must be at most 100 characters.");

        RuleFor(e => e.JoinedDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Joined date cannot be in the future.");

        RuleFor(e => e.DepartmentId).NotEmpty().WithMessage("Department ID is required.");
    }
}
