using System;
using R2ETien.EFCore.Application.DTOs.Salary;
using R2ETien.EFCore.Domain.Entities;

namespace R2ETien.EFCore.Mapping;

public static class SalaryMapping
{
 public static SalaryDTO ToDto(this Salary salary)
    {
        return new SalaryDTO(salary.Id, salary.EmployeeId, salary.Amount);
    }

    public static Salary ToEntity(this CreateSalaryDTO dto)
    {
        return new Salary
        {
            Id = Guid.NewGuid(),
            EmployeeId = dto.EmployeeId,
            Amount = dto.SalaryAmount,
        };
    }

    public static void UpdateFromDto(this Salary salary, UpdateSalaryDTO dto)
    {
        salary.Amount = dto.SalaryAmount;
    }
}
