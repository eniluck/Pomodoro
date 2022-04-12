using Pomodoro.Core;
using Pomodoro.Core.Models;

namespace Pomodoro.BL
{
    public class TaskCategoriesService : ITaskCategoriesService
    {
        private readonly ITaskCategoryRepository _taskCategoryRepository;

        public TaskCategoriesService(ITaskCategoryRepository taskCategoryRepository)
        {
            _taskCategoryRepository = taskCategoryRepository;
        }

        public async Task<TaskCategory> AddCategoryAsync(TaskCategory categoryRequest)
        {
            return await _taskCategoryRepository.AddAsync(categoryRequest);
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            return await _taskCategoryRepository.RemoveAsync(categoryId);
        }

        public async Task<List<TaskCategory>> GetAllTaskCategoriesAsync()
        {
            return await _taskCategoryRepository.GetAllAsync();
        }

        public async Task<TaskCategory> GetAsync(int categoryId)
        {
            return await _taskCategoryRepository.GetAsync(categoryId);
        }

        public async Task<bool> UpdateCategory(TaskCategory categoryRequest)
        {
            return await _taskCategoryRepository.UpdateAsync(categoryRequest);
        }
    }
}