using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using R2ETien.EFCore.Domain.Entities;
using R2ETien.EFCore.Infrastructure.Data;

namespace R2ETien.EFCore.Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Department entity)
    {
        await _context.Departments.AddAsync(entity);
    }

    public void Delete(Department entity)
    {
        _context.Departments.Remove(entity);
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _context.Departments.AsNoTracking().ToListAsync();
    }

    public async Task<Department?> GetByIdAsync(Guid id)
    {
        return await _context
            .Departments.Include(d => d.Employees)
            .ThenInclude(e => e.Salary)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Department entity)
    {
        _context.Departments.Update(entity);
    }
}
