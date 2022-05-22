using CSharpFunctionalExtensions;

namespace Pomodoro.Core;

public interface ITimerService
{
    public Task<Result> StartAsync(int taskId);
}
