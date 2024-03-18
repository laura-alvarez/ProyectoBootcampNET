using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.Data.Data;

namespace TaskManager.Infrastructure.Data.Repositories
{
        public class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            public DataContext _context;

            public GenericRepository(DataContext context)
            {
                _context = context;
            }

            public async Task AddAsync(T entity)
            {
                await Task.Run(() => _context.Set<T>().AddAsync(entity));
            }

            public async Task DeleteAsync(int id)
            {
                var entity = await Task.Run(() => GetByIdSync(id));
                _context.Set<T>().Remove(entity);
            }

            public async Task<IEnumerable<T>> GetAllAsync()
            {
                return await Task.Run(() => _context.Set<T>().ToList());
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

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }
        }   
}
