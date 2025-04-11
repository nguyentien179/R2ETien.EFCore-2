using System;
using Microsoft.EntityFrameworkCore;
using R2ETien.EFCore.Domain.Entities;
using R2ETien.EFCore.Infrastructure.Data;

namespace R2ETien.EFCore.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Project entity)
    {
        await _context.Projects.AddAsync(entity);
    }

    public void Delete(Project entity)
    {
        _context.Projects.Remove(entity);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Projects.AnyAsync(p => p.Id == id);
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Projects.AnyAsync(p => p.Name == name);
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _context
            .Projects.Include(p => p.ProjectEmployees)
            .ThenInclude(pe => pe.Employee)
            .ThenInclude(e => e!.Salary)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(Guid id)
    {
        return await _context
            .Projects.Include(p => p.ProjectEmployees)
            .ThenInclude(pe => pe.Employee)
            .ThenInclude(e => e!.Salary)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Project entity)
    {
        _context.Projects.Update(entity);
    }
}
