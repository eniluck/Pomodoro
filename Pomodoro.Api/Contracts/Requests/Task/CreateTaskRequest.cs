using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Api.Contracts.Requests.Task
{
    public class CreateTaskRequest
    {
        public string Name { get; set; } = string.Empty;

        public int? CategoryId { get; set; }
    }
}