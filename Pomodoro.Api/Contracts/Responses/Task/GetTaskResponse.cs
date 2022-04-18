using Pomodoro.Core.Models;

namespace Pomodoro.Api.Contracts.Responses.Task
{
    public class GetTaskResponse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public GetCategoryResponse? Category { get; set; }

        public TaskStatusModel Status { get; set; }

        public int PomodoroEstimation { get; set; }
    }
}
