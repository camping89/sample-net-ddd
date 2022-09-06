using System.Linq.Expressions;

namespace SampleDDD.Domain;

public interface IBaseRepository<T> where  T : BaseEntity
{
    Task<T> AddAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task DeleteAsync(T entity);
    Task DeleteAsync(Guid id);

    Task<T?> GetAsync(Expression<Func<T, bool>> expression);
    Task<T?> GetAsync(Guid id);

    Task<List<T>> GetListAsync(Expression<Func<T, bool>>? expression = null);

    Task SaveChangesAsync();
}