using Pomodoro.Core.Models;

namespace Pomodoro.DAL.MSSQL.Repositories
{
    public interface ITaskCategoryRepository
    {
        Task<TaskCategory> AddAsync(TaskCategory taskCategory);
        Task<List<TaskCategory>> GetAllAsync();
        Task<TaskCategory> GetAsync(int id);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(TaskCategory taskCategory);
    }
}
