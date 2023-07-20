
using Microsoft.EntityFrameworkCore;
using TraningApp.Backend.Services;
using TraningApp.Backend.Data;
using System.Linq;

public class EfCoreRepository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public EfCoreRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T> Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(Guid id)
    {
        T entity = await _context.Set<T>().FindAsync(id);

        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<T?> Get(Guid id)
    {
        T entity = await _context.Set<T>().FindAsync(id);
        return entity;
    }

    public async Task<IEnumerable<T>> GetAll(int? page, int? limit)
    {
        IQueryable<T> entities = _context.Set<T>().AsQueryable();  
        if(page != null)
        {
            entities = entities.Skip(page.Value);
        }
        if(limit != null)
        {
            entities = entities.Take(limit.Value);
        }

        IEnumerable<T> filteredEntities = await entities.ToListAsync();
        
        return filteredEntities;
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

}