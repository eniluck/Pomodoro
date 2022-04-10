namespace Pomodoro.Core.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public TaskCategory? Category { get; set; }

        public TaskStatusModel Status { get; set; }

        public int Count { get; set; }
    }
}
