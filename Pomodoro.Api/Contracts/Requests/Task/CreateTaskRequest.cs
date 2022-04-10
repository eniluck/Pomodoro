using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Api.Contracts.Requests.Task
{
    public class CreateTaskRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public TaskCategoryRequest? Category { get; set; }
    }
}