﻿namespace Pomodoro.Api.Contracts.Responses.Task
{
    public class TaskResponse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public TaskCategoryResponse? Category { get; set; }

        public TaskStatusResponse Status { get; set; }

        public int PomodoroEstimation { get; set; }
    }
}