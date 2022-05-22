using CSharpFunctionalExtensions;

namespace Pomodoro.Core;

public interface ITimerService
{
    Task<Result> StartAsync(int taskId);
}
