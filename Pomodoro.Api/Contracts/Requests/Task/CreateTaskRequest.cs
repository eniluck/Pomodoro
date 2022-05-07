using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Api.Contracts.Requests.Task
{
    public class CreateTaskRequest
    {
        [Required]
        [MaxLength(1024)]
        public string Name { get; set; } = string.Empty;

        public int? CategoryId { get; set; }
    }
}