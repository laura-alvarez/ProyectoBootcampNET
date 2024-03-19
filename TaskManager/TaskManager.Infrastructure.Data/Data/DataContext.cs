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
            modelBuilder.Entity<UserEntity>()
                .HasOne(o => o.UserCreate)
                .WithMany()
                .HasForeignKey(o => o.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<UserEntity>()
                .HasOne(o => o.UserUpdate)
                .WithMany()
                .HasForeignKey(o => o.UpdatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(o => o.UserCreate)
                .WithMany()
                .HasForeignKey(o => o.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(o => o.UserUpdate)
                .WithMany()
                .HasForeignKey(o => o.UpdatedBy)
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

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Task { get; set; }
        public DbSet<StateEntity> States { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}
