using System;
using FluentValidation;
using R2ETien.EFCore.Application.DTOs.ProjectEmployee;
using R2ETien.EFCore.Infrastructure.Repositories;

namespace R2ETien.EFCore.Application.DTOs.ProjectEmployeeValidation;

public class CreateProjectEmployeeValidator : AbstractValidator<CreateProjectEmployeeDTO>
{
    public CreateProjectEmployeeValidator(
        IEmployeeRepository employeeRepo,
        IProjectRepository projectRepo,
        IProjectEmployeeRepository projectEmployeeRepo
    )
    {
        RuleFor(x => x.ProjectId)
            .NotEmpty()
            .WithMessage("ProjectId is required.")
            .MustAsync(async (id, _) => await projectRepo.ExistsAsync(id))
            .WithMessage("Project does not exist.");

        RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .WithMessage("EmployeeId is required.")
            .MustAsync(async (id, _) => await employeeRepo.ExistsAsync(id))
            .WithMessage("Employee does not exist.");

        RuleFor(x => x.Enable)
            .Must(v => v == true || v == false)
            .WithMessage("Enable must be either true or false");

        RuleFor(x => x)
            .MustAsync(
                async (dto, _) =>
                    !await projectEmployeeRepo.ExistsAsync(dto.ProjectId, dto.EmployeeId)
            )
            .WithMessage("This employee is already assigned to the project.");
    }
}
