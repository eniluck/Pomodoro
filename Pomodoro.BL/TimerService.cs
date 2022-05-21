using Pomodoro.Core;
using Pomodoro.Core.Models;

namespace Pomodoro.BL
{
    public class TimerService : ITimerService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskHistoryRepository _taskHistoryRepository;

        public TimerService(ITaskRepository taskRepository,
                ITaskHistoryRepository taskHistoryRepository)
        {
            _taskRepository = taskRepository;
            _taskHistoryRepository = taskHistoryRepository;
        }

        public async Task StartAsync(int taskId)
        {
            // есть ли такая задача?
            var existedTask = await _taskRepository.GetAsync(taskId);

            if (existedTask == null)
            {
                throw new Exception($"Не найдена задача с id = {taskId}");
            }

            var runningTask = existedTask.Start(existedTask);
            await _taskRepository.UpdateAsync(runningTask);

            // TODO: далее мы должны начать логировать время начала выполнения и время окончания выполнения
            var taskHistory = new TaskHistory(0, runningTask, DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(25));
            await _taskHistoryRepository.AddAsync(taskHistory);
        }
    }
}
