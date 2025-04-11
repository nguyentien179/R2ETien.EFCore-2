using System;
using FluentValidation;
using R2ETien.EFCore.Application.DTOs.Project;

namespace R2ETien.EFCore.Application.DTOs.ProjectValidation;

public class UpdateProjectValidatorDTO : AbstractValidator<UpdateProjectDTO>
{
    public UpdateProjectValidatorDTO()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
    }
}
