using Pomodoro.Core.Models;

namespace Pomodoro.Core
{
    public interface ITaskCategoryRepository
    {
        Task<TaskCategory?> AddAsync(TaskCategory taskCategory);

        Task<TaskCategory[]> GetAllAsync();

        Task<TaskCategory> GetAsync(int id);

        Task<bool> RemoveAsync(int id);

        Task<bool> UpdateAsync(TaskCategory taskCategory);
    }
}
