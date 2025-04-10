using System;
using R2ETien.EFCore.Application.Common.Constants;
using R2ETien.EFCore.Application.DTOs.Salary;
using R2ETien.EFCore.Application.Interfaces;
using R2ETien.EFCore.Infrastructure.Repositories;
using R2ETien.EFCore.Mapping;

namespace R2ETien.EFCore.Application.Services;

public class SalaryService : ISalaryService
{
    private readonly ISalaryRepository _repository;

    public SalaryService(ISalaryRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CreateSalaryDTO dto)
    {
        await _repository.AddAsync(dto.ToEntity());
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid employeeId)
    {
        var salary = await _repository.GetByEmployeeIdAsync(employeeId);
        if (salary == null)
            throw new KeyNotFoundException(ErrorMessages.NotFound);
        _repository.Delete(salary);
        await _repository.SaveChangesAsync();
    }

    public async Task<SalaryDTO?> GetByEmployeeIdAsync(Guid employeeId)
    {
        var salary = await _repository.GetByEmployeeIdAsync(employeeId);
        return salary == null
            ? throw new KeyNotFoundException(ErrorMessages.NotFound)
            : salary.ToDto();
    }

    public async Task UpdateAsync(Guid employeeId, UpdateSalaryDTO dto)
    {
        var salary = await _repository.GetByEmployeeIdAsync(employeeId);
        if (salary == null)
        {
            throw new KeyNotFoundException(ErrorMessages.NotFound);
        }
        salary.UpdateFromDto(dto);
        _repository.Update(salary);
        await _repository.SaveChangesAsync();
    }
}
