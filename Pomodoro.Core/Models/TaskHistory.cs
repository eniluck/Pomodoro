namespace Pomodoro.Core.Models;

public record TaskHistory
{
    public TaskHistory(int id, TaskModel task, DateTime createDateTime, DateTime startDateTime, DateTime stopDateTime)
    {
        Id = id;
        Task = task;
        CreateDateTime = createDateTime;
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
    /// Время добавления в историю.
    /// </summary>
    public DateTime CreateDateTime { get; }

    /// <summary>
    /// Начало выполнения задачи.
    /// </summary>
    public DateTime StartDateTime { get; }

    /// <summary>
    /// Окончание выполнения задачи.
    /// </summary>
    public DateTime StopDateTime { get; }
}
