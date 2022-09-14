using System.Linq.Expressions;

namespace NLayerApp.Core.Repositories.Abstracts;

public interface IGenericRepository<T> where T : class,new()
{
    Task<T> GetByIdAsync(int id);
    IQueryable<T> Where(Expression<Func<T,bool>> expression);
    IQueryable<T> GetAll(Expression<Func<T,bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
    void Delete(T entity);

}