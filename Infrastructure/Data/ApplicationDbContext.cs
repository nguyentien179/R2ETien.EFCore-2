using System;
using Microsoft.EntityFrameworkCore;
using R2ETien.EFCore.Domain.Entities;

namespace R2ETien.EFCore.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<ProjectEmployee> ProjectEmployees => Set<ProjectEmployee>();
    public DbSet<Salary> Salaries => Set<Salary>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(d => d.Name).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

            entity.Property(e => e.JoinedDate).HasDefaultValueSql("GETDATE()");

            entity
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => new { e.Name, e.DepartmentId }).IsUnique();
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.Property(s => s.Amount).IsRequired().HasColumnType("decimal(18,2)");

            entity
                .HasOne(s => s.Employee)
                .WithOne(e => e.Salary)
                .HasForeignKey<Salary>(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(s => s.EmployeeId).IsUnique();
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entity.HasIndex(p => p.Name).IsUnique();
        });

        modelBuilder.Entity<ProjectEmployee>(entity =>
        {
            entity.HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            entity.Property(pe => pe.Enable).HasDefaultValue(true);

            entity
                .HasOne(pe => pe.Employee)
                .WithMany(e => e.ProjectEmployees)
                .HasForeignKey(pe => pe.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasOne(pe => pe.Project)
                .WithMany(p => p.ProjectEmployees)
                .HasForeignKey(pe => pe.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // === Define Static GUIDs ===
        var deptHR = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var deptIT = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var deptFin = Guid.Parse("33333333-3333-3333-3333-333333333333");

        var empAlice = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        var empBob = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        var empCharlie = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");

        var projApollo = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
        var projHermes = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");

        modelBuilder
            .Entity<Department>()
            .HasData(
                new Department { Id = deptHR, Name = "HR" },
                new Department { Id = deptIT, Name = "IT" },
                new Department { Id = deptFin, Name = "Finance" }
            );

        modelBuilder
            .Entity<Project>()
            .HasData(
                new Project { Id = projApollo, Name = "Apollo" },
                new Project { Id = projHermes, Name = "Hermes" }
            );

        modelBuilder
            .Entity<Employee>()
            .HasData(
                new Employee
                {
                    Id = empAlice,
                    Name = "Alice",
                    DepartmentId = deptHR,
                    JoinedDate = new DateOnly(2023, 1, 1),
                },
                new Employee
                {
                    Id = empBob,
                    Name = "Bob",
                    DepartmentId = deptIT,
                    JoinedDate = new DateOnly(2022, 5, 20),
                },
                new Employee
                {
                    Id = empCharlie,
                    Name = "Charlie",
                    DepartmentId = deptFin,
                    JoinedDate = new DateOnly(2021, 11, 15),
                }
            );

        modelBuilder
            .Entity<Salary>()
            .HasData(
                new Salary
                {
                    Id = Guid.Parse("fa111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    EmployeeId = empAlice,
                    Amount = 5000,
                },
                new Salary
                {
                    Id = Guid.Parse("fa222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    EmployeeId = empBob,
                    Amount = 6000,
                },
                new Salary
                {
                    Id = Guid.Parse("fa333333-cccc-cccc-cccc-cccccccccccc"),
                    EmployeeId = empCharlie,
                    Amount = 5500,
                }
            );

        modelBuilder
            .Entity<ProjectEmployee>()
            .HasData(
                new ProjectEmployee
                {
                    ProjectId = projApollo,
                    EmployeeId = empAlice,
                    Enable = true,
                },
                new ProjectEmployee
                {
                    ProjectId = projApollo,
                    EmployeeId = empBob,
                    Enable = true,
                },
                new ProjectEmployee
                {
                    ProjectId = projHermes,
                    EmployeeId = empCharlie,
                    Enable = true,
                }
            );
    }
}
