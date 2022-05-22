using CSharpFunctionalExtensions;
using Pomodoro.Core;
using Pomodoro.Core.Models;

namespace Pomodoro.BL
{
    public class TimerService : ITimerService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskHistoryRepository _taskHistoryRepository;

        public TimerService(
            ITaskRepository taskRepository,
            ITaskHistoryRepository taskHistoryRepository)
        {
            _taskRepository = taskRepository;
            _taskHistoryRepository = taskHistoryRepository;
        }

        public async Task<Result> StartAsync(int taskId)
        {
            var existedTask = await _taskRepository.GetAsync(taskId);
            if (existedTask == null)
            {
                return Result.Failure($"Не найдена задача с id = {taskId}");
            }

            var runningTask = existedTask.Start();
            if (runningTask.IsFailure)
            {
                return runningTask;
            }

            var pomodoro = TaskHistory.Create(
                runningTask.Value,
                DateTime.Now,
                DateTime.Now.AddMinutes(TaskHistory.POMODORO_LENGTH));
            if (pomodoro.IsFailure)
            {
                return pomodoro;
            }

            await _taskHistoryRepository.AddAsync(pomodoro.Value);
            return Result.Success();
        }
    }
}
