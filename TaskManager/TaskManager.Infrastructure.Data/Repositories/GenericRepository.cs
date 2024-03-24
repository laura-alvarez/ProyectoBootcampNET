using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.Data.Data;

namespace TaskManager.Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : LogicDeleteEntity
    {
        public DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await Task.Run(() => GetByIdSync(id));
            entity.IsDelete = true;
            await Task.Run(() => _context.Set<T>().Update(entity));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (_context)
            {
                return await Task.Run(() => _context.Set<T>().Where(x=> !x.IsDelete).ToList());
            }
        }

        public T GetByIdSync(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _context.Set<T>().Update(entity));
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            int result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
