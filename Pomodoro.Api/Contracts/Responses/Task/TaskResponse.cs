using Pomodoro.Api.Contracts.Responses.Task;

namespace Pomodoro.Api.Contracts.Responses
{
    public class TaskResponse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public TaskCategoryResponse? Category { get; set; }

        public TaskStatusResponse Status { get; set; }

        public int Count { get; set; }
    }
}
