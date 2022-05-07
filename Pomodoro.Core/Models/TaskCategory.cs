namespace Pomodoro.Core.Models
{
    public record TaskCategory
    {
        public TaskCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static (TaskCategory? Result, string[] Errors) Create(string name)
        {
            return Create(0, name);
        }

        public static (TaskCategory? Result, string[] Errors) Create(int id, string name)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add($"{nameof(Name)} cannot be null or whitespace.");
            }

            if (id < 0)
            {
                errors.Add($"{nameof(id)} must be positive.");
            }

            if (errors.Count > 0)
            {
                return (null, errors.ToArray());
            }

            var newTaskCategory = new TaskCategory(id, name);
            return (newTaskCategory, Array.Empty<string>());
        }
    }
}
