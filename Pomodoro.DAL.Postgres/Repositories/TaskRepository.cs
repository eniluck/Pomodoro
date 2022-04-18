using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pomodoro.Core;
using Pomodoro.Core.Models;
using Pomodoro.DAL.Postgres.Entities;

namespace Pomodoro.DAL.Postgres.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMapper _mapper;
        private readonly PomodoroDbContext _pomodoroDbContext;

        public TaskRepository(IMapper mapper, PomodoroDbContext pomodoroDbContext)
        {
            _mapper = mapper;
            _pomodoroDbContext = pomodoroDbContext;
        }

        public async Task<List<TaskModel>> GetAllAsync()
        {
            var tasks = await _pomodoroDbContext.Tasks
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<TaskEntity>, List<TaskModel>>(tasks);
        }

        public async Task<TaskModel> GetAsync(int id)
        {
            var task = await _pomodoroDbContext.Tasks
                .AsNoTracking()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<TaskEntity, TaskModel>(task);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var task = _pomodoroDbContext.Tasks
                .Where(t => t.Id == id)
                .FirstOrDefault();

            if (task != null)
            {
                _pomodoroDbContext.Tasks.Remove(task);
                var removedEntitesCount = await _pomodoroDbContext.SaveChangesAsync();
                return removedEntitesCount > 0;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(TaskModel task)
        {
            var taskEntity = _mapper.Map<TaskModel, TaskEntity>(task);
            _pomodoroDbContext.Entry(taskEntity.Category).State = EntityState.Unchanged;
            _pomodoroDbContext.Tasks.Update(taskEntity);

            var updatedEntitesCount = await _pomodoroDbContext.SaveChangesAsync();
            return updatedEntitesCount > 0;
        }

        public async Task<TaskModel> AddAsync(TaskModel task)
        {
            var taskEntity = _mapper.Map<TaskModel, TaskEntity>(task);
            _pomodoroDbContext.Tasks.Add(taskEntity);

            if (taskEntity.Category is not null)
            {
                _pomodoroDbContext.TaskCategories.Attach(taskEntity.Category);
            }

            var addeddEntitesCount = await _pomodoroDbContext.SaveChangesAsync();
            if (addeddEntitesCount > 0)
            {
                return _mapper.Map<TaskEntity, TaskModel>(taskEntity);
            }
            else
            {
                return null;
            }
        }
    }
}
