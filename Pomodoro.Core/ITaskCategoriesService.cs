using Pomodoro.Core.Models;

namespace Pomodoro.Core
{
    public interface ITaskCategoriesService
    {
        Task<TaskCategory[]> GetAllTaskCategoriesAsync();

        Task<TaskCategory> AddCategoryAsync(TaskCategory categoryRequest);

        Task<bool> UpdateCategory(TaskCategory categoryRequest);

        Task<bool> DeleteCategory(int categoryId);

        Task<TaskCategory> GetAsync(int categoryId);
    }
}
