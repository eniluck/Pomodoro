namespace Pomodoro.Core.Models
{
    public record TaskModel
    {
        public const int MAX_NAME_LENGTH = 1024;

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

        //public void AddCategory(TaskCategory? taskCategory) { Category = taskCategory; }

        public TaskStatusModel Status { get; init }

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
                errors.Add($"{nameof(Name)} cannot be null or whitespace." );
            }

            if (name.Length > MAX_NAME_LENGTH)
            {
                errors.Add($"Maximum string length of {nameof(Name)} equals {MAX_NAME_LENGTH}.");
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

        public TaskModel Start(TaskModel existedTask)
        {
            switch (existedTask.Status)
            {
                case TaskStatusModel.InProgress:
                    throw new Exception($"Задача с id = {existedTask.Id} уже выполняется");
                case TaskStatusModel.Ready:
                    throw new Exception($"Задача с id = {existedTask.Id} уже выполнена");
                case TaskStatusModel.InList:
                    return new TaskModel(existedTask) with { Status = TaskStatusModel.InProgress };
                default:
                    throw new Exception($"Неизвестный статус текущей задачи");
            }
        }
    }
}
