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
        try
        {
            await _repository.AddAsync(dto.ToEntity());
            await _repository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Log it or inspect
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
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

    public async Task<IEnumerable<EmployeeWithProjectsDTO>> GetAllAsyncRawSql()
    {
        return await _repository.GetAllAsyncRawSql();
    }

    public async Task<IEnumerable<EmployeeWithProjectsDTO>> GetAllWithProjectsAsync()
    {
        var employees = await _repository.GetAllWithProjectsAsync();
        return employees.Where(e => e is not null)!;
    }

    public async Task<IEnumerable<EmployeeWithProjectsDTO>> GetAllWithProjectsRawSqlAsync()
    {
        return await _repository.GetAllWithProjectsRawSqlAsync();
    }

    public async Task<IEnumerable<EmployeeWithProjectsDTO>> GetAllWithSalaryLargerThan100()
    {
        var employees = await _repository.GetEmployeeWithSalaryGreaterThan100();
        return employees.Where(e => e is not null)!;
    }

    public async Task<EmployeeDTO?> GetByIdAsync(Guid id)
    {
        var employee = await _repository.GetByIdAsync(id);
        return employee == null
            ? throw new KeyNotFoundException(ErrorMessages.NotFound)
            : employee.ToDto();
    }

    public async Task<
        IEnumerable<EmployeeWithProjectsDTO>
    > GetEmployeesWithSalaryGreaterThan100RawSql()
    {
        return await _repository.GetEmployeesWithSalaryGreaterThan100RawSql();
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
