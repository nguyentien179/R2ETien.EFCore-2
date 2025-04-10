using System;
using Microsoft.EntityFrameworkCore;
using R2ETien.EFCore.Domain.Entities;
using R2ETien.EFCore.Infrastructure.Data;

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

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.AsNoTracking().ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(Guid id)
    {
        return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Employee entity)
    {
        _context.Employees.Update(entity);
    }
}
