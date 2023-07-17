namespace TraningApp.Backend.Services;

public interface IRepository<T>
{
    Task<T> Create(T entity);
    Task<T?> Get(Guid id);
    Task Update(T entity);
    Task Delete(Guid id);
    Task<IEnumerable<T>> GetAll();
}
