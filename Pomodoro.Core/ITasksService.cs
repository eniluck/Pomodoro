using Pomodoro.Core.Models;

namespace Pomodoro.Core
{
    public interface ITasksService
    {
        Task<(TaskModel? Result, string[] Errors)> CreateTaskAsync(TaskModel taskModel, int? categoryId);

        Task<bool> DeleteTaskAsync(int taskId);

        Task<TaskModel[]> GetAllTasksAsync();

        Task<bool> UpdateTaskAsync(TaskModel taskModel);
    }
}