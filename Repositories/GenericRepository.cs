using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Interfaces;

namespace Mini_Theatre.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>[] predicates = null,
                                                           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                           string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            // filter
            if (predicates != null)
            {
                foreach(var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
            }

            // include properties
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            // order
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                                 .AsQueryable()
                                 .ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            _context.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
