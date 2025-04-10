using System;
using R2ETien.EFCore.Domain.Entities;

namespace R2ETien.EFCore.Infrastructure.Repositories;

public interface ISalaryRepository
{
    Task<Salary?> GetByEmployeeIdAsync(Guid employeeId);
    Task AddAsync(Salary salary);
    void Update(Salary salary);
    void Delete(Salary salary);
    Task SaveChangesAsync();
}
