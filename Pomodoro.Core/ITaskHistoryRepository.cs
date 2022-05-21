using Pomodoro.Core.Models;

namespace Pomodoro.Core;

public interface ITaskHistoryRepository
{
    Task<TaskHistory?> AddAsync(TaskHistory taskHistory);
}
