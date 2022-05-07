using System.ComponentModel.DataAnnotations;

namespace Pomodoro.DAL.Postgres.Entities
{
    public class TaskCategoryEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
