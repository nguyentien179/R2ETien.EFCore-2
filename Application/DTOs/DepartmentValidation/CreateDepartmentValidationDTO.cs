using System;
using FluentValidation;
using R2ETien.EFCore.Application.DTOs.Department;
using R2ETien.EFCore.Infrastructure.Repositories;

namespace R2ETien.EFCore.Application.DTOs.DepartmentValidation;

public class CreateDepartmentValidationDTO : AbstractValidator<CreateDepartmentDTO>
{
    public CreateDepartmentValidationDTO(IDepartmentRepository departmentRepo)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can not be empty")
            .MustAsync(async (name, _) => !await departmentRepo.ExistsByNameAsync(name))
            .WithMessage("A department with this name already exists.");
    }
}
