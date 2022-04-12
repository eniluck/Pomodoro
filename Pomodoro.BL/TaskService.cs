using Pomodoro.Core;
using Pomodoro.Core.Models;

namespace Pomodoro.BL
{
    public class TaskService : ITasksService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskModel> CreateTaskAsync(TaskModel taskModel)
        {
            return await _taskRepository.AddAsync(taskModel);
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            return await _taskRepository.RemoveAsync(taskId);
        }

        public async Task<List<TaskModel>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<bool> UpdateTaskAsync(TaskModel taskModel)
        {
            return await _taskRepository.UpdateAsync(taskModel);
        }
    }
}
