using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Pomodoro.Core;
using Pomodoro.Core.Models;
using Pomodoro.DAL.Postgres.Entities;

namespace Pomodoro.DAL.Postgres.Repositories;

public class TaskHistoryRepository : ITaskHistoryRepository
{
    private readonly IMapper _mapper;
    private readonly PomodoroDbContext _pomodoroDbContext;

    public TaskHistoryRepository(
        IMapper mapper,
        PomodoroDbContext pomodoroDbContext)
    {
        _mapper = mapper;
        _pomodoroDbContext = pomodoroDbContext;
    }

    public async Task<Result> AddAsync(TaskHistory taskHistory)
    {
        var task = taskHistory.Task;

        var existedTask = await _pomodoroDbContext.Tasks
                .Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(tc => tc.Id == task.Id);

        if (existedTask is null)
        {
            return Result.Failure($"Задача не найдена с id={task.Id}");
        }

        var taskEntity = new TaskEntity()
        {
            Id = existedTask.Id,
            Status = task.Status,
            Name = existedTask.Name,
            CategoryId = existedTask.Category?.Id,
            PomodoroEstimation = existedTask.PomodoroEstimation,
        };

        _pomodoroDbContext.Tasks.Update(taskEntity);

        var taskHistoryEntity = new TaskHistoryEntity()
        {
            TaskId = task.Id,
            Start = taskHistory.StartDateTime,
            Stop = taskHistory.StopDateTime,
        };

        _pomodoroDbContext.TaskHistories.Add(taskHistoryEntity);

        await _pomodoroDbContext.SaveChangesAsync();

        return Result.Success();
    }
}
