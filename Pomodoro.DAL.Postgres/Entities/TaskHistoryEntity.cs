namespace Pomodoro.DAL.Postgres.Entities;

public class TaskHistoryEntity
{
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
    /// Начало выполнения задачи.
    /// </summary>
    public DateTime Start { get; set; }

    /// <summary>
    /// Окончание выполнения задачи.
    /// </summary>
    public DateTime Stop { get; set; }
}
