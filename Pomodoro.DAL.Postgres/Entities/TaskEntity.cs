namespace Pomodoro.DAL.Postgres.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public TaskCategoryEntity? Category { get; set; }

        public TaskStatusEntity Status { get; set; }

        public int PomodoroEstimation { get; set; }
    }
}
