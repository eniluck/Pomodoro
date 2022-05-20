namespace Pomodoro.Core;

public interface ITimerService
{
    public Task StartAsync(int taskId);
}
