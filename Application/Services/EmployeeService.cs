using System;
using R2ETien.EFCore.Application.Common.Constants;
using R2ETien.EFCore.Application.DTOs.Employee;
using R2ETien.EFCore.Application.Interfaces;
using R2ETien.EFCore.Infrastructure.Repositories;
using R2ETien.EFCore.Mapping;

namespace R2ETien.EFCore.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CreateEmployeeDTO dto)
    {
        await _repository.AddAsync(dto.ToEntity());
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var employee = await _repository.GetByIdAsync(id);
        if (employee == null)
            throw new KeyNotFoundException(ErrorMessages.NotFound);
        _repository.Delete(employee);
        await _repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
    {
        var employees = await _repository.GetAllAsync();
        return employees.Select(e => e.ToDto());
    }

    public async Task<EmployeeDTO?> GetByIdAsync(Guid id)
    {
        var employee = await _repository.GetByIdAsync(id);
        return employee == null
            ? throw new KeyNotFoundException(ErrorMessages.NotFound)
            : employee.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateEmployeeDTO dto)
    {
        var employee = await _repository.GetByIdAsync(id);
        if (employee == null)
        {
            throw new KeyNotFoundException(ErrorMessages.NotFound);
        }
        employee.Name = dto.Name;
        employee.DepartmentId = dto.DepartmentId;
        employee.JoinedDate = dto.JoinedDate;
        _repository.Update(employee);
        await _repository.SaveChangesAsync();
    }
}
