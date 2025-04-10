using System;
using Microsoft.EntityFrameworkCore;
using R2ETien.EFCore.Domain.Entities;
using R2ETien.EFCore.Infrastructure.Data;

namespace R2ETien.EFCore.Infrastructure.Repositories.Interfaces;

public class ProjectEmployeeRepository : IProjectEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectEmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProjectEmployee>> GetAllAsync()
    {
        return await _context
            .ProjectEmployees.Include(pe => pe.Project)
            .Include(pe => pe.Employee)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ProjectEmployee?> GetByIdsAsync(Guid projectId, Guid employeeId)
    {
        return await _context.ProjectEmployees.FirstOrDefaultAsync(pe =>
            pe.ProjectId == projectId && pe.EmployeeId == employeeId
        );
    }

    public async Task AddAsync(ProjectEmployee projectEmployee)
    {
        await _context.ProjectEmployees.AddAsync(projectEmployee);
    }

    public void Update(ProjectEmployee projectEmployee)
    {
        _context.ProjectEmployees.Update(projectEmployee);
    }

    public void Delete(ProjectEmployee projectEmployee)
    {
        _context.ProjectEmployees.Remove(projectEmployee);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
