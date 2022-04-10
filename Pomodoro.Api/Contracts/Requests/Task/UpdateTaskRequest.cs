namespace Pomodoro.Api.Contracts.Requests.Task
{
    public class UpdateTaskRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public TaskCategoryRequest? Category { get; set; }

        public TaskStatusRequest? Status { get; set; }

        public int Count { get; set; }
    }
}
