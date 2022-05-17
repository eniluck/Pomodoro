using System.ComponentModel.DataAnnotations;
using Pomodoro.Core.Models;

namespace Pomodoro.Api.Contracts.Requests.Task
{
    public class CreateTaskRequest
    {
        [Required]
        [MaxLength(TaskModel.MAX_NAME_LENGTH)]
        public string Name { get; set; } = string.Empty;

        public int? CategoryId { get; set; }
    }
}