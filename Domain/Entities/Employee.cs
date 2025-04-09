using System;

namespace R2ETien.EFCore.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public DateTime JoinedDate { get; set; }
    public Guid DepartmentId { get; set; }
    public Department? Department { get; set; }
    public Salary? Salary { get; set; }
    public ICollection<ProjectEmployee> ProjectEmployees { get; set; } =
        new List<ProjectEmployee>();
}
