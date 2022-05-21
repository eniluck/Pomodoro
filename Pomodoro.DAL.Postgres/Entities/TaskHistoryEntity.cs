namespace Pomodoro.DAL.Postgres.Entities;

public class TaskHistoryEntity
{
    public TaskHistoryEntity(int id, int taskId, DateTime createDateTime, DateTime startDateTime, DateTime stopDateTime)
    {
        Id = id;
        TaskId = taskId;
        CreateDateTime = createDateTime;
        StartDateTime = startDateTime;
        StopDateTime = stopDateTime;
    }

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор задачи.
    /// </summary>
    public int TaskId { get; set; }

    /// <summary>
    /// Задача.
    /// </summary>
    public TaskEntity Task { get; set; }

    /// <summary>
    /// Время добавления в историю.
    /// </summary>
    public DateTime CreateDateTime { get; set; }

    /// <summary>
    /// Начало выполнения задачи.
    /// </summary>
    public DateTime StartDateTime { get; set; }

    /// <summary>
    /// Окончание выполнения задачи.
    /// </summary>
    public DateTime StopDateTime { get; set; }
}
