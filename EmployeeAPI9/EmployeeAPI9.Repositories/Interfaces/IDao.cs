namespace EmployeeAPI9.Repositories.Interfaces;

// Dit is je generieke klasse definiëren, staat altijd vast
public interface IDao<T> where T : class
{
    Task<IEnumerable<T>?> GetAllAsync();
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
    Task<T?> FindByIdAsync(int Id);
}