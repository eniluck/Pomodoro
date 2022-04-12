using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Api.Contracts.Requests.Task
{
    public class CreateTaskCategoryRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
