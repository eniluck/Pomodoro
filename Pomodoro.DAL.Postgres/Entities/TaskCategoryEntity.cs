using System.ComponentModel.DataAnnotations;

namespace Pomodoro.DAL.Postgres.Entities
{
    public class TaskCategoryEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
