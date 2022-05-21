using AutoMapper;
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

    public async Task<TaskHistory?> AddAsync(TaskHistory taskHistory)
    {
        var taskHistoryEntity = _mapper.Map<TaskHistory, TaskHistoryEntity>(taskHistory);

        _pomodoroDbContext.ChangeTracker.Clear();

        if (taskHistoryEntity.Task is not null)
        {
            //taskHistoryEntity.Task = null; // лучший вариант ? нет. т.к. существует проблема в том что отдавать сущность нужно с этими данными

            _pomodoroDbContext.Tasks.Attach(taskHistoryEntity.Task); // ошибка

            /*var taskExisted = await _pomodoroDbContext.Tasks // не нравится что ещё раз приходится обращаться к бд
                .Where(tc => tc.Id == taskHistoryEntity.TaskId)
                .FirstOrDefaultAsync();

            taskHistoryEntity.Task = taskExisted; // и ещё подменять приходится. */
        }

        _pomodoroDbContext.TaskHistories.Add(taskHistoryEntity);

        var addeddEntitesCount = await _pomodoroDbContext.SaveChangesAsync();
        var result = _mapper.Map<TaskHistoryEntity, TaskHistory>(taskHistoryEntity);
        return addeddEntitesCount > 0 ? result : null;
    }
}
