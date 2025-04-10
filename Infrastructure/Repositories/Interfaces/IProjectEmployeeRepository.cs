using System;
using R2ETien.EFCore.Domain.Entities;

namespace R2ETien.EFCore.Infrastructure.Repositories;

public interface IProjectEmployeeRepository
{
    Task<IEnumerable<ProjectEmployee>> GetAllAsync();
    Task<ProjectEmployee?> GetByIdsAsync(Guid projectId, Guid employeeId);
    Task AddAsync(ProjectEmployee entity);
    void Update(ProjectEmployee entity);
    void Delete(ProjectEmployee entity);
    Task SaveChangesAsync();
}
