using Pomodoro.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Api.Contracts.Requests.Task
{
    public class UpdateTaskRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int? CategoryId { get; set; }

        public TaskStatusModel Status { get; set; }

        public int PomodoroEstimation { get; set; }
    }
}
