namespace MinimalWebApi.Repositories;

public interface IRepository<T>
{
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
}