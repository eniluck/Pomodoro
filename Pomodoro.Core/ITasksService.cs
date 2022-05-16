using Pomodoro.Core.Models;

namespace Pomodoro.Core
{
    public interface ITasksService
    {
        Task<(TaskModel? Result, string[] Errors)> CreateTaskAsync(TaskModel taskModel, int? categoryId);

        Task DeleteTaskAsync(int taskId);

        Task<TaskModel[]> GetAllTasksAsync();

        Task<(bool Result, string[] Errors)> UpdateTaskAsync(TaskModel taskModel, int? categoryId);
    }
}