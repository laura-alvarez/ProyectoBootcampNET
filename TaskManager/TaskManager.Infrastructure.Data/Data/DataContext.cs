using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Task { get; set; }
        public DbSet<StateEntity> States { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}
