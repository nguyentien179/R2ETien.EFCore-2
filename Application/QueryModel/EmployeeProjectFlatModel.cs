using System;

namespace R2ETien.EFCore.Application.DTOs;

public record EmployeeProjectFlatModel(
    Guid EmployeeId,
    string EmployeeName,
    DateOnly JoinedDate,
    Guid DepartmentId,
    string DepartmentName,
    decimal? SalaryAmount,
    Guid? ProjectId,
    string? ProjectName
);
