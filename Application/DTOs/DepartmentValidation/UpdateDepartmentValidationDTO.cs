using System;
using FluentValidation;
using R2ETien.EFCore.Application.DTOs.Department;

namespace R2ETien.EFCore.Application.DTOs.DepartmentValidation;

public class UpdateDepartmentValidationDTO : AbstractValidator<UpdateDepartmentDTO>
{
    public UpdateDepartmentValidationDTO()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
    }
}
