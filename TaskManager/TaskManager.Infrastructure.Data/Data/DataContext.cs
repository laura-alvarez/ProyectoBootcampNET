using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<TaskEntity>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(o => o.Category)
                .WithMany()
                .HasForeignKey(o => o.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(o => o.State)
                .WithMany()
                .HasForeignKey(o => o.StateId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<TaskEntity> Task { get; set; }
        public DbSet<StateEntity> State { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
    }
}
