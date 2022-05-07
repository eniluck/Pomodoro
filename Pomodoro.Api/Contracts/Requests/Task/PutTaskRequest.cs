using System.ComponentModel.DataAnnotations;
using Pomodoro.Core.Models;

namespace Pomodoro.Api.Contracts.Requests.Task
{
    public class PutTaskRequest
    {
        [Required]
        [MaxLength(1024)]
        public string Name { get; set; } = string.Empty;

        public int? CategoryId { get; set; }

        public TaskStatusModel Status { get; set; }

        public int? PomodoroEstimation { get; set; }
    }
}
