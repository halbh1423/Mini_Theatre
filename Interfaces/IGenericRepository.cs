using System.Linq.Expressions;

namespace Mini_Theatre.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // Create
        Task<T> AddAsync(T entity);

        // Read
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAsync
        (
            Expression<Func<T, bool>>[] predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = ""
        );

        // Update
        Task<T> UpdateAsync(T entity);

        // Delete
        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}
