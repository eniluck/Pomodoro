using Pomodoro.Core.Models;

namespace Pomodoro.Core
{
    public interface ITaskRepository
    {
        Task<TaskModel> AddAsync(TaskModel task);

        Task<TaskModel[]> GetAllAsync();

        Task<TaskModel> GetAsync(int id);

        Task<bool> RemoveAsync(int id);

        Task<bool> UpdateAsync(TaskModel task);
    }
}