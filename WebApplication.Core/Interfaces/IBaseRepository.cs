namespace WebApplication.Core.Interfaces;
public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetByExprissionAsync(Expression<Func<T, bool>> expression);
    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task<T> DeleteAsync(Guid id);
    Task<T> EditAsync(T entity);
}