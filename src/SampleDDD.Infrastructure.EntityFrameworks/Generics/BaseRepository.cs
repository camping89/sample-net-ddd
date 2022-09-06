using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SampleDDD.Domain;
using SampleDDD.Infrastructure.EntityFrameworks.EntityFrameworkCore;

namespace SampleDDD.Infrastructure.EntityFrameworks.Generics;

public class BaseRepository<T>  : IBaseRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;
    private readonly SampleDbContext _dbContext;
    public BaseRepository(SampleDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }
    
    public Task<T> AddAsync(T entity)
    {
        _dbSet.AddAsync(entity);
        
        return Task.FromResult(entity);
    }

    public Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    public Task<T?> GetAsync(Expression<Func<T, bool>> expression)
    {
        return _dbSet.FirstOrDefaultAsync(expression);
    }


    public Task<T?> GetAsync(Guid id)
    {
        return _dbSet.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public Task<List<T>> GetListAsync(Expression<Func<T, bool>>? expression)
    {
        return expression != null ? _dbSet.Where(expression).ToListAsync() : _dbSet.ToListAsync();
    }

    public Task SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
}