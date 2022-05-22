using CSharpFunctionalExtensions;
using Pomodoro.Core.Models;

namespace Pomodoro.Core;

public interface ITaskHistoryRepository
{
    Task<Result> AddAsync(TaskHistory taskHistory);
}
