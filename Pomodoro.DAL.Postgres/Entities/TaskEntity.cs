using Pomodoro.Core.Models;

namespace Pomodoro.DAL.Postgres.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int? CategoryId { get; set; }

        public TaskCategoryEntity? Category { get; set; }

        public TaskStatusModel Status { get; set; } = TaskStatusModel.InList;

        public int? PomodoroEstimation { get; set; }
    }
}
