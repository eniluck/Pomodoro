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

        public async Task<TaskModel[]> GetAllAsync()
        {
            var tasks = await _pomodoroDbContext.Tasks
                .AsNoTracking()
                .ToArrayAsync();

            return _mapper.Map<TaskEntity[], TaskModel[]>(tasks);
        }

        public async Task<TaskModel> GetAsync(int id)
        {
            var task = await _pomodoroDbContext.Tasks
                .AsNoTracking()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<TaskEntity, TaskModel>(task);
        }

        public async Task RemoveAsync(int id)
        {
            var task = _pomodoroDbContext.Tasks
                .Where(t => t.Id == id)
                .FirstOrDefault();

            if (task == null)
            {
                throw new Exception($"Задача с id ={id} не найдена для удаления");
            }

            _pomodoroDbContext.Tasks.Remove(task);
            var removedEntitesCount = await _pomodoroDbContext.SaveChangesAsync();
            if (removedEntitesCount == 0)
            {
                throw new Exception("Задача с id ={id} не удалена");
            }
        }

        public async Task<bool> UpdateAsync(TaskModel task)
        {
            var taskExisted = await _pomodoroDbContext.Tasks
                .AsNoTracking()
                .Where(tc => tc.Id == task.Id)
                .FirstOrDefaultAsync();

            if (taskExisted is null)
            {
                return false;
            }

            var taskEntity = _mapper.Map<TaskModel, TaskEntity>(task);
            if (taskEntity.Category is not null)
            {
                _pomodoroDbContext.Entry(taskEntity.Category).State = EntityState.Unchanged;
            }

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
