namespace Pomodoro.Core.Models
{
    public record TaskModel
    {
        private TaskModel(string name, TaskCategory? category, TaskStatusModel status, int? pomodoroEstimation)
        {
            Name = name;
            Category = category;
            Status = status;
            PomodoroEstimation = pomodoroEstimation;
        }

        public int Id { get; init; }

        public string Name { get; }

        public TaskCategory? Category { get; init; }

        public TaskStatusModel Status { get; }

        public int? PomodoroEstimation { get; }

        public static (TaskModel? Result, string[] Errors) Create(string name)
        {
            return Create(name, null, TaskStatusModel.InList, 1);
        }

        public static (TaskModel? Result, string[] Errors) Create(string name, TaskCategory? taskCategory, TaskStatusModel taskStatus, int? pomodoroEstimation)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add($"{nameof(name)} cannot be null or whitespace." );
            }

            if (!Enum.IsDefined(typeof(TaskStatusModel), taskStatus))
            {
                errors.Add($"{nameof(taskStatus)} must be defined in enum.");
            }

            if (pomodoroEstimation.HasValue && pomodoroEstimation < 0)
            {
                errors.Add($"{nameof(pomodoroEstimation)} must be positive.");
            }

            if (errors.Count > 0)
            {
                return (null, errors.ToArray());
            }

            var result = new TaskModel(name, taskCategory, taskStatus, pomodoroEstimation);
            return (result, Array.Empty<string>());
        }
    }
}
