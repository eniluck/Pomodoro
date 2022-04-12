namespace Pomodoro.Core.Models
{
    public class TaskCategory
    {
        public TaskCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string? Name { get; }

        public static (TaskCategory? Result, string[] Errors) Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return (null, new[] { "Name cannot be null or whitespace." });
            }

            var newTaskCategory = new TaskCategory(0, name);
            return (newTaskCategory, Array.Empty<string>());
        }
    }
}
