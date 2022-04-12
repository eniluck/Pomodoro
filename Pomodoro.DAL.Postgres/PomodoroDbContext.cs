using Microsoft.EntityFrameworkCore;
using Pomodoro.DAL.Postgres.Entities;

namespace Pomodoro.DAL.Postgres
{
    public class PomodoroDbContext : DbContext
    {
        public PomodoroDbContext(DbContextOptions<PomodoroDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);

        public DbSet<TaskCategoryEntity> TaskCategories { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }
    }
}