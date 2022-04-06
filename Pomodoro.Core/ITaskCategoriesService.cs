using Pomodoro.Core.Models;

namespace Pomodoro.Core
{
    public interface ITaskCategoriesService
    {
        List<TaskCategory> GetAllTasks();
        TaskCategory CreateCategory(TaskCategory categoryRequest);
        bool UpdateCategory(TaskCategory categoryRequest);
        bool DeleteCategory(int categoryId);
    }
}
