namespace Pomodoro.Core.Models
{
    public record TaskModel
    {
        private TaskModel(int id, string name, TaskCategory? category, TaskStatusModel status, int pomodoroEstimation)
        {
            Id = id;
            Name = name;
            Category = category;
            Status = status;
            PomodoroEstimation = pomodoroEstimation;
        }

        public int Id { get; }

        public string Name { get; }

        public TaskCategory? Category { get; }

        public TaskStatusModel Status { get; }

        public int PomodoroEstimation { get; }

        public static (TaskModel? Result, string[] Errors) Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return (null, new[] { "Name cannot be null or whitespace." });
            }

            var result = new TaskModel(0, name, null, TaskStatusModel.InList, 1);
            return (result, Array.Empty<string>());
        }
    }
}
