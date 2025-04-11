using System;
using Microsoft.EntityFrameworkCore;
using R2ETien.EFCore.Application.DTOs.Employee;
using R2ETien.EFCore.Application.DTOs.Project;
using R2ETien.EFCore.Domain.Entities;
using R2ETien.EFCore.Infrastructure.Data;
using R2ETien.EFCore.Mapping;

namespace R2ETien.EFCore.Infrastructure.Repositories.Interfaces;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Employee entity)
    {
        await _context.Employees.AddAsync(entity);
    }

    public void Delete(Employee entity)
    {
        _context.Employees.Remove(entity);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Employees.AnyAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context
            .Employees.Include(e => e.Salary)
            .Include(e => e.Department)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(Guid id)
    {
        return await _context
            .Employees.Include(e => e.Salary)
            .Include(e => e.Department)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Employee entity)
    {
        _context.Employees.Update(entity);
    }

    public async Task<IEnumerable<EmployeeWithProjectsDTO?>> GetAllWithProjectsAsync()
    {
        var employees = await _context
            .Employees.Include(e => e.Department)
            .Include(e => e.Salary)
            .Include(e => e.ProjectEmployees)
            .ThenInclude(pe => pe.Project)
            .ToListAsync();

        return employees.Select(e => e.ToDtoWithProjects());
    }

    public async Task<IEnumerable<EmployeeWithProjectsDTO>> GetEmployeeWithSalaryGreaterThan100()
    {
        var employees = await _context
            .Employees.Include(e => e.Department)
            .Include(e => e.Salary)
            .Include(e => e.ProjectEmployees)
            .ThenInclude(pe => pe.Project)
            .Where(e => e.Salary != null && e.Salary.Amount > 100)
            .ToListAsync();

        return employees.Select(e => e.ToDtoWithProjects());
    }

    public async Task<IEnumerable<EmployeeWithProjectsDTO>> GetAllWithProjectsRawSqlAsync()
    {
        var data = await _context
            .EmployeeProjectFlatModel.FromSqlRaw(
                @"
            SELECT 
                e.Id AS EmployeeId,
                e.Name AS EmployeeName,
                e.JoinedDate,
                e.DepartmentId,
                d.Name AS DepartmentName,
                s.Amount AS SalaryAmount,
                p.Id AS ProjectId,
                p.Name AS ProjectName
            FROM Employees e
            LEFT JOIN Departments d ON e.DepartmentId = d.Id
            LEFT JOIN Salaries s ON s.EmployeeId = e.Id
            LEFT JOIN ProjectEmployees pe ON pe.EmployeeId = e.Id
            LEFT JOIN Projects p ON p.Id = pe.ProjectId
        "
            )
            .ToListAsync();

        var grouped = data.GroupBy(x => new
            {
                x.EmployeeId,
                x.EmployeeName,
                x.JoinedDate,
                x.DepartmentId,
                x.DepartmentName,
                x.SalaryAmount,
            })
            .Select(g => new EmployeeWithProjectsDTO(
                g.Key.EmployeeId,
                g.Key.EmployeeName,
                g.Key.JoinedDate,
                g.Key.DepartmentId,
                g.Key.DepartmentName,
                g.Key.SalaryAmount,
                g.Where(p => p.ProjectId.HasValue)
                    .Select(p => new ProjectDTO(
                        p.ProjectId!.Value,
                        p.ProjectName!,
                        new List<EmployeeDTO>()
                    ))
                    .ToList()
            ));

        return grouped;
    }

    public async Task<IEnumerable<EmployeeWithProjectsDTO>> GetAllAsyncRawSql()
    {
        var data = await _context
            .EmployeeProjectFlatModel.FromSqlRaw(
                @"
            SELECT 
                e.Id AS EmployeeId,
                e.Name AS EmployeeName,
                e.JoinedDate,
                e.DepartmentId,
                d.Name AS DepartmentName,
                s.Amount AS SalaryAmount,
                p.Id AS ProjectId,
                p.Name AS ProjectName
            FROM Employees e
            LEFT JOIN Departments d ON e.DepartmentId = d.Id
            LEFT JOIN Salaries s ON s.EmployeeId = e.Id
            LEFT JOIN ProjectEmployees pe ON pe.EmployeeId = e.Id
            LEFT JOIN Projects p ON p.Id = pe.ProjectId
        "
            )
            .ToListAsync();

        return data.GroupBy(x => new
            {
                x.EmployeeId,
                x.EmployeeName,
                x.JoinedDate,
                x.DepartmentId,
                x.DepartmentName,
                x.SalaryAmount,
            })
            .Select(g => new EmployeeWithProjectsDTO(
                g.Key.EmployeeId,
                g.Key.EmployeeName,
                g.Key.JoinedDate,
                g.Key.DepartmentId,
                g.Key.DepartmentName,
                g.Key.SalaryAmount,
                g.Where(p => p.ProjectId.HasValue)
                    .Select(p => new ProjectDTO(
                        p.ProjectId!.Value,
                        p.ProjectName!,
                        new List<EmployeeDTO>()
                    ))
                    .ToList()
            ));
    }

    public async Task<
        IEnumerable<EmployeeWithProjectsDTO>
    > GetEmployeesWithSalaryGreaterThan100RawSql()
    {
        var data = await _context
            .EmployeeProjectFlatModel.FromSqlRaw(
                @"
            SELECT 
                e.Id AS EmployeeId,
                e.Name AS EmployeeName,
                e.JoinedDate,
                e.DepartmentId,
                d.Name AS DepartmentName,
                s.Amount AS SalaryAmount,
                p.Id AS ProjectId,
                p.Name AS ProjectName
            FROM Employees e
            LEFT JOIN Departments d ON e.DepartmentId = d.Id
            LEFT JOIN Salaries s ON s.EmployeeId = e.Id
            LEFT JOIN ProjectEmployees pe ON pe.EmployeeId = e.Id
            LEFT JOIN Projects p ON p.Id = pe.ProjectId
            WHERE s.Amount > 100
        "
            )
            .ToListAsync();

        return data.GroupBy(x => new
            {
                x.EmployeeId,
                x.EmployeeName,
                x.JoinedDate,
                x.DepartmentId,
                x.DepartmentName,
                x.SalaryAmount,
            })
            .Select(g => new EmployeeWithProjectsDTO(
                g.Key.EmployeeId,
                g.Key.EmployeeName,
                g.Key.JoinedDate,
                g.Key.DepartmentId,
                g.Key.DepartmentName,
                g.Key.SalaryAmount,
                g.Where(p => p.ProjectId.HasValue)
                    .Select(p => new ProjectDTO(
                        p.ProjectId!.Value,
                        p.ProjectName!,
                        new List<EmployeeDTO>()
                    ))
                    .ToList()
            ));
    }
}
