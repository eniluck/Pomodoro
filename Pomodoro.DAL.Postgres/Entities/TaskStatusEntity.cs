namespace Pomodoro.DAL.Postgres.Entities
{
    public enum TaskStatusEntity
    {
        /// <summary>
        /// Задача для выполнения. Значение по умолчанию.
        /// </summary>
        InList = 0,

        /// <summary>
        /// Задача выполняется в данный момент.
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// Задача выполнена.
        /// </summary>
        Ready = 2,
    }
}