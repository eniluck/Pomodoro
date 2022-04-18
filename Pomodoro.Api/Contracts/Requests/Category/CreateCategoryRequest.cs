using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Api.Contracts.Requests.Task
{
    public class CreateCategoryRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
