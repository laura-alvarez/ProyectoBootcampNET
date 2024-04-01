using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.Data.Data;

namespace TaskManager.Infrastructure.Data.Repositories
{
    public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<TaskEntity>> GetAll()
        {
            return await Task.Run(() => _context.Set<TaskEntity>().Include(t => t.Category).Include(t => t.State).Where(x => !x.IsDelete).ToList());            
        }
        public async Task<IEnumerable<TaskEntity>> GetAllByUserIdAsync(int idUser)
        {
           return await Task.Run(() => _context.Set<TaskEntity>().Include(t => t.Category).Include(t => t.State).Where(task => task.UserId == idUser && !task.IsDelete).ToList());
           
        }


    }
}
