using System;
using FluentValidation;
using R2ETien.EFCore.Application.DTOs.Project;
using R2ETien.EFCore.Infrastructure.Repositories;

namespace R2ETien.EFCore.Application.DTOs.ProjectValidation;

public class CreateProjectValidatorDTO : AbstractValidator<CreateProjectDTO>
{
    public CreateProjectValidatorDTO(IProjectRepository projectRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can not be empty")
            .MustAsync(async (name, _) => !await projectRepository.ExistsByNameAsync(name))
            .WithMessage("Project name already exists.");
    }
}
