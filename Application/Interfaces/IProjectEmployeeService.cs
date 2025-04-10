using R2ETien.EFCore.Application.DTOs.ProjectEmployee;

namespace R2ETien.EFCore.Application.Interfaces;

public interface IProjectEmployeeService
{
    Task<IEnumerable<ProjectEmployeeDTO>> GetAllAsync();

    Task<ProjectEmployeeDTO?> GetByIdsAsync(Guid projectId, Guid employeeId);

    Task AssignAsync(CreateProjectEmployeeDTO dto);

    Task UpdateAsync(Guid projectId, Guid employeeId, UpdateProjectEmployeDTO dto);

    Task RemoveAsync(Guid projectId, Guid employeeId);
}
