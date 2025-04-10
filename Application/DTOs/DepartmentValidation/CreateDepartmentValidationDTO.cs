using System;
using FluentValidation;
using R2ETien.EFCore.Application.DTOs.Department;

namespace R2ETien.EFCore.Application.DTOs.DepartmentValidation;

public class CreateDepartmentValidationDTO : AbstractValidator<CreateDepartmentDTO>
{
    public CreateDepartmentValidationDTO()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
    }
}
