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

        public Task<List<TaskEntity>> GetAllByUserIdAsync(int idUser)
        {
           return _context.Set<TaskEntity>().Where(task => task.UserId == idUser).ToListAsync();
           
        }


    }
}
