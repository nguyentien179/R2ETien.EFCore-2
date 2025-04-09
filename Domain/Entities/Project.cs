using System;

namespace R2ETien.EFCore.Domain.Entities;

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;

    public ICollection<ProjectEmployee> ProjectEmployees { get; set; } =
        new List<ProjectEmployee>();
}
