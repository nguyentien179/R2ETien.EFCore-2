using System;
using Microsoft.EntityFrameworkCore;
using R2ETien.EFCore.Domain.Entities;
using R2ETien.EFCore.Infrastructure.Data;

namespace R2ETien.EFCore.Infrastructure.Repositories;

public class SalaryRepository : ISalaryRepository
{
    private readonly ApplicationDbContext _context;

    public SalaryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Salary?> GetByEmployeeIdAsync(Guid employeeId)
    {
        return await _context.Salaries.FirstOrDefaultAsync(s => s.EmployeeId == employeeId);
    }

    public async Task AddAsync(Salary salary)
    {
        await _context.Salaries.AddAsync(salary);
    }

    public void Update(Salary salary)
    {
        _context.Salaries.Update(salary);
    }

    public void Delete(Salary salary)
    {
        _context.Salaries.Remove(salary);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
