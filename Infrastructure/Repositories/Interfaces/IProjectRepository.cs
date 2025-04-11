using System;
using R2ETien.EFCore.Domain.Entities;

namespace R2ETien.EFCore.Infrastructure.Repositories;

public interface IProjectRepository : IRepository<Project>
{
    Task<bool> ExistsAsync(Guid id);
    Task<bool> ExistsByNameAsync(string name);
}
