namespace TraningApp.Backend.Services;

public interface IRepository<T>
{
    Task<T> Create(T entity);
    Task<T?> Get(int id);
    Task Update(T entity);
    Task Delete(int id);
    Task<IEnumerable<T>> GetAll(int? skip, int? limit);
    Task<T?> FindBy(Func<T, bool> selector);
    Task<IEnumerable<T?>> FindManyBy(Func<T, bool> selector, int? page, int? limit);
    
}
