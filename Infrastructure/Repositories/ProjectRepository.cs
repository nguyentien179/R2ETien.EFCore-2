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

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _context.Projects.AsNoTracking().ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(Guid id)
    {
        return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
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
