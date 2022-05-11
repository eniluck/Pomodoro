namespace Pomodoro.Core.Models
{
    public record TaskCategory
    {
        public TaskCategory(string name)
        {
            Name = name;
        }

        public int Id { get; init; }

        public string Name { get; }

        public static (TaskCategory? Result, string[] Errors) Create(string name)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add($"{nameof(Name)} cannot be null or whitespace.");
            }

            if (errors.Count > 0)
            {
                return (null, errors.ToArray());
            }

            var newTaskCategory = new TaskCategory(name);
            return (newTaskCategory, Array.Empty<string>());
        }
    }
}
