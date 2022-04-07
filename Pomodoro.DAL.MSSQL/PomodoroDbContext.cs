using Microsoft.EntityFrameworkCore;
using Pomodoro.DAL.MSSQL.Entities;

namespace Pomodoro.DAL.MSSQL
{
    public class PomodoroDbContext : DbContext
    {
        public DbSet<TaskCategoryEntity> TaskCategories { get; set; }
    }
}