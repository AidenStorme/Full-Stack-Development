using EmployeeAPI9.Domain.DataDB;
using EmployeeAPI9.Domain.EntitiesDB;
using EmployeeAPI9.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI9.Repositories;

public class EmployeeDao : IDao<Employee>
{
    private readonly EmployeeDbContext _context;

    public EmployeeDao(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>?> GetAllAsync()
    {
        return await _context.Employees.AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Employee entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _context.Employees.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Employee entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _context.Employees.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _context.Employees.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Employee?> FindByIdAsync(int Id)
    {
        return await _context.Employees.FindAsync(Id);
    }
}