namespace Pomodoro.Api.Contracts.Requests.Task
{
    public class CreateTaskRequest
    {
        public string? Name { get; set; }

        public TaskCategoryRequest? Category { get; set; }
    }
}