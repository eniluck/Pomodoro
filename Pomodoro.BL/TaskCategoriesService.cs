using Pomodoro.Core;
using Pomodoro.Core.Models;

namespace Pomodoro.BL
{
    public class TaskCategoriesService : ITaskCategoriesService
    {
        public TaskCategory CreateCategory(TaskCategory categoryRequest)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<TaskCategory> GetAllTaskCategories()
        {
            return new List<TaskCategory>()
            {
                new TaskCategory()
                {
                    Name = "Задача 1",
                    Id = 1
                },
                new TaskCategory()
                {
                    Name = "Задача 2",
                    Id = 2
                },
            };
        }

        public bool UpdateCategory(TaskCategory categoryRequest)
        {
            throw new NotImplementedException();
        }
    }
}