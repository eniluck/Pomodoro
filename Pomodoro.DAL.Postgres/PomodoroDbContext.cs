using Microsoft.EntityFrameworkCore;
using Pomodoro.DAL.Postgres.Configurations;
using Pomodoro.DAL.Postgres.Entities;

namespace Pomodoro.DAL.Postgres
{
    public class PomodoroDbContext : DbContext
    {
        public PomodoroDbContext(DbContextOptions<PomodoroDbContext> options)
            : base(options)
        { }

        public DbSet<TaskCategoryEntity> TaskCategories { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TaskCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}