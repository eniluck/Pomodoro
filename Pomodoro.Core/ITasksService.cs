using Pomodoro.Core.Models;

namespace Pomodoro.Core
{
    public interface ITasksService
    {
        List<TaskModel> GetAllTasks();

        TaskModel CreateTask(TaskModel createTaskRequest);

        bool UpdateTask(TaskModel updateTaskRequest);

        bool DeleteTask(int taskId);
    }
}