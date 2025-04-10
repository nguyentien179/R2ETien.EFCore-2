namespace R2ETien.EFCore.Application.DTOs.ProjectEmployee;

public record class CreateProjectEmployeeDTO(Guid ProjectId, Guid EmployeeId, bool Enable);
