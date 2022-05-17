using Pomodoro.Core.Models;

namespace Pomodoro.Api.Contracts.Responses.Task
{
    public class GetTaskResponse
    {
        public GetTaskResponse(int id, string? name, GetCategoryResponse? category, TaskStatusModel status, int pomodoroEstimation)
        {
            Id = id;
            Name = name;
            Category = category;
            Status = status;
            PomodoroEstimation = pomodoroEstimation;
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public GetCategoryResponse? Category { get; set; }

        public TaskStatusModel Status { get; set; }

        public int PomodoroEstimation { get; set; }
    }
}
