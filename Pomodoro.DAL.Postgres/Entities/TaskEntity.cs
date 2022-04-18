using Pomodoro.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Pomodoro.DAL.Postgres.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public TaskCategoryEntity? Category { get; set; }

        public TaskStatusModel Status { get; set; }

        public int PomodoroEstimation { get; set; }
    }
}
