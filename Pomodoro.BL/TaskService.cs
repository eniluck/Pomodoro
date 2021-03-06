using Pomodoro.Core;
using Pomodoro.Core.Models;

namespace Pomodoro.BL
{
    public class TaskService : ITasksService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskCategoryRepository _taskCategoryRepository;

        public TaskService(
            ITaskRepository taskRepository,
            ITaskCategoryRepository taskCategoryRepository)
        {
            _taskRepository = taskRepository;
            _taskCategoryRepository = taskCategoryRepository;
        }

        public async Task<(TaskModel? Result, string[] Errors)> CreateTaskAsync(TaskModel taskModel, int? categoryId)
        {
            TaskCategory? existedCategory = null;

            if (categoryId is not null)
            {
                existedCategory = await _taskCategoryRepository.GetAsync(categoryId.Value);

                if (existedCategory is null)
                {
                    var error = new string[] { "Не найдена категория по Id" };
                    return (null, error);
                }
            }

            /*taskModel.Category = existedCategory;

            taskModel.AddCategory(existedCategory);*/

            return (await _taskRepository.AddAsync(
                taskModel with { Category = existedCategory }),
                Array.Empty<string>());
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            await _taskRepository.RemoveAsync(taskId);
        }

        public async Task<TaskModel[]> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<(bool Result, string[] Errors)> UpdateTaskAsync(TaskModel taskModel, int? categoryId)
        {
            TaskCategory? existedCategory = null;

            if (categoryId is not null)
            {
                existedCategory = await _taskCategoryRepository.GetAsync(categoryId.Value);

                if (existedCategory is null)
                {
                    var error = new string[] { "Не найдена категория по Id" };
                    return (false, error);
                }
            }

            return (await _taskRepository.UpdateAsync(
               taskModel with { Category = existedCategory }),
               Array.Empty<string>());
        }
    }
}
