namespace Pomodoro.Core.Models
{
    public record TaskModel
    {
        private TaskModel(int id, string name, TaskCategory? category, TaskStatusModel status, int? pomodoroEstimation)
        {
            Id = id;
            Name = name;
            Category = category;
            Status = status;
            PomodoroEstimation = pomodoroEstimation;
        }

        public int Id { get; }

        public string Name { get; }

        public TaskCategory? Category { get; init; }

        //public void AddCategory(TaskCategory? taskCategory) { Category = taskCategory; }

        public TaskStatusModel Status { get; }

        public int? PomodoroEstimation { get; }

        public static (TaskModel? Result, string[] Errors) Create(string name)
        {
            return Create(0, name, null, TaskStatusModel.InList, 1);
        }

        public static (TaskModel? Result, string[] Errors) Create(int id, string name, TaskCategory? taskCategory, TaskStatusModel taskStatus, int? pomodoroEstimation)
        {
            var errors = new List<string>();

            if (id < 0)
            {
                errors.Add($"{nameof(id)} must be positive.");
            }

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

            var result = new TaskModel(id, name, taskCategory, taskStatus, pomodoroEstimation);
            return (result, Array.Empty<string>());
        }
    }
}
