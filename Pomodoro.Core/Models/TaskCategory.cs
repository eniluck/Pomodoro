namespace Pomodoro.Core.Models
{
    public record TaskCategory
    {
        public const int MAX_NAME_LENGTH = 100;

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

            if (name.Length > MAX_NAME_LENGTH)
            {
                errors.Add($"Maximum string length of {nameof(Name)} equals {MAX_NAME_LENGTH}.");
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
