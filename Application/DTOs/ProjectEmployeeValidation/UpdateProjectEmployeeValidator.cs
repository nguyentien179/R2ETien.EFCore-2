using System;
using FluentValidation;
using R2ETien.EFCore.Application.DTOs.ProjectEmployee;

namespace R2ETien.EFCore.Application.DTOs.ProjectEmployeeValidation;

public class UpdateProjectEmployeeValidator : AbstractValidator<UpdateProjectEmployeDTO>
{
    public UpdateProjectEmployeeValidator()
    {
        RuleFor(x => x.Enable)
            .Must(v => v == true || v == false)
            .WithMessage("Enable must be either true or false");
    }
}
