using Microsoft.EntityFrameworkCore;
using Pomodoro.DAL.Postgres.Entities;

namespace Pomodoro.DAL.Postgres
{
    public class PomodoroDbContext : DbContext
    {
        public PomodoroDbContext(DbContextOptions<PomodoroDbContext> options) : base(options)
        {

        }

        public DbSet<TaskCategoryEntity> TaskCategories { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
    }
}