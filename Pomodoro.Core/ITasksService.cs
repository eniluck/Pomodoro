using Pomodoro.Core.Models;

namespace Pomodoro.Core
{
    public interface ITasksService
    {
        Task<TaskModel> CreateTaskAsync(TaskModel taskModel);

        Task<bool> DeleteTaskAsync(int taskId);

        Task<List<TaskModel>> GetAllTasksAsync();

        Task<bool> UpdateTaskAsync(TaskModel taskModel);
    }
}