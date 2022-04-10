using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pomodoro.Core;
using Pomodoro.Core.Models;
using Pomodoro.DAL.Postgres.Entities;

namespace Pomodoro.DAL.Postgres.Repositories
{
    public class TaskCategoryRepository : ITaskCategoryRepository
    {
        private readonly IMapper _mapper;
        private readonly PomodoroDbContext _pomodoroDbContext;

        public TaskCategoryRepository(IMapper mapper, PomodoroDbContext pomodoroDbContext)
        {
            _mapper = mapper;
            _pomodoroDbContext = pomodoroDbContext;
        }

        public async Task<List<TaskCategory>> GetAllAsync()
        {
            var taskCategories = await _pomodoroDbContext.TaskCategories
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<TaskCategory>>(taskCategories);
        }

        public async Task<TaskCategory> GetAsync(int id)
        {
            var taskCategory = await _pomodoroDbContext.TaskCategories
                .AsNoTracking()
                .Where(tc => tc.Id == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<TaskCategory>(taskCategory);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var taskCategory = await _pomodoroDbContext.TaskCategories
                .AsNoTracking()
                .Where(tc => tc.Id == id)
                .FirstOrDefaultAsync();

            if (taskCategory != null)
            {
                _pomodoroDbContext.Remove(taskCategory);
                var removedEntitesCount = await _pomodoroDbContext.SaveChangesAsync();
                return removedEntitesCount > 0;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(TaskCategory taskCategory)
        {
            var taskCategoryEntity = _mapper.Map<TaskCategoryEntity>(taskCategory);

            _pomodoroDbContext.Update(taskCategoryEntity);
            var updatedEntitesCount = await _pomodoroDbContext.SaveChangesAsync();
            return updatedEntitesCount > 0;
        }

        public async Task<TaskCategory?> AddAsync(TaskCategory taskCategory)
        {
            var taskCategoryEntity = _mapper.Map<TaskCategoryEntity>(taskCategory);
            _pomodoroDbContext.Add(taskCategoryEntity);
            var addeddEntitesCount = await _pomodoroDbContext.SaveChangesAsync();
            if (addeddEntitesCount > 0)
            {
                return _mapper.Map<TaskCategory>(taskCategoryEntity);
            }
            else
            {
                return null; //Task.FromResult(null);
            }
        }
    }
}
