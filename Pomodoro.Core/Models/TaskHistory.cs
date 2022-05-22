using CSharpFunctionalExtensions;

namespace Pomodoro.Core.Models;

public record TaskHistory
{
    public const int POMODORO_LENGTH = 25;

    private TaskHistory(int id, TaskModel task, DateTime startDateTime, DateTime stopDateTime)
    {
        Id = id;
        Task = task;
        StartDateTime = startDateTime;
        StopDateTime = stopDateTime;
    }

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get;  }

    /// <summary>
    /// Задача.
    /// </summary>
    public TaskModel Task { get; }

    /// <summary>
    /// Начало выполнения задачи.
    /// </summary>
    public DateTime StartDateTime { get; }

    /// <summary>
    /// Окончание выполнения задачи.
    /// </summary>
    public DateTime StopDateTime { get; }

    public static Result<TaskHistory> Create(TaskModel task, DateTime startDateTime, DateTime stopDateTime)
    {
        if (stopDateTime < startDateTime)
        {
            return Result.Failure<TaskHistory>("Дата окончания должна быть больше даты начала");
            // TODO: переделать чтобы было более информативно
        }

        return new TaskHistory(0, task, startDateTime, stopDateTime);
    }
}
