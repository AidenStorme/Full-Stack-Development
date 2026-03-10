using EmployeeAPI9.Domain.EntitiesDB;
using EmployeeAPI9.Services.Interfaces;
using EmployeeAPI9.Repositories.Interfaces;

namespace EmployeeAPI9.Services;

public class EmployeeService : IService<Employee>
{
    private readonly IDao<Employee> _employeeDao; // depend on DAO, not the service interface

    public EmployeeService(IDao<Employee> employeeDao)
    {
        _employeeDao = employeeDao;
    }

    public async Task<IEnumerable<Employee>?> GetAllAsync()
    {
        return await _employeeDao.GetAllAsync();
    }

    public Task AddAsync(Employee entity)
    {
        // Delegate creation to the DAO implementation
        return _employeeDao.AddAsync(entity);
    }

    public Task DeleteAsync(Employee entity)
    {
        return _employeeDao.DeleteAsync(entity);
    }

    public Task UpdateAsync(Employee entity)
    {
        return _employeeDao.UpdateAsync(entity);
    }

    public async Task<Employee?> FindByIdAsync(int id)
    {
        return await _employeeDao.FindByIdAsync(id);
    }
}