using Pomodoro.Core.Models;

namespace Pomodoro.Core
{
    public interface ITaskCategoriesService
    {
        Task<List<TaskCategory>> GetAllTaskCategoriesAsync();

        Task<TaskCategory> AddCategoryAsync(TaskCategory categoryRequest);

        Task<bool> UpdateCategory(TaskCategory categoryRequest);

        Task<bool> DeleteCategory(int categoryId);
    }
}
