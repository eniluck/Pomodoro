using Pomodoro.Core;

namespace Pomodoro.BL
{
    public class TimerService : ITimerService
    {
        private readonly ITaskRepository _taskRepository;

        public TimerService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
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
        }
    }
}
