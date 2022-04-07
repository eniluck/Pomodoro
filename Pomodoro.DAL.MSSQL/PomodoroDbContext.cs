using Microsoft.EntityFrameworkCore;
using Pomodoro.DAL.MSSQL.Entities;

namespace Pomodoro.DAL.MSSQL
{
    public class PomodoroDbContext : DbContext
    {
        public PomodoroDbContext(DbContextOptions<PomodoroDbContext> options):base(options)
        {

        }

        public DbSet<TaskCategoryEntity> TaskCategories { get; set; }
    }
}