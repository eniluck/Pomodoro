using Microsoft.AspNetCore.Mvc;
using Pomodoro.Api.Contracts.Requests.Task;

namespace Pomodoro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _tasksService.GetAllTasks();

            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult CreateTask(CreateTaskRequest createTaskRequest)
        {
            var newTask = _tasksService.CreateTask(createTaskRequest);

            return Ok(newTask);
        }

        [HttpDelete]
        public IActionResult DeleteTask(int taskId)
        {
            var deleteResult = _tasksService.DeleteTask(taskId);

            return Ok(deleteResult);
        }

        [HttpPut]
        public IActionResult UpdateTask(UpdateTaskRequest updateTaskRequest)
        {
            var updateResult = _tasksService.UpdateTask(updateTaskRequest);

            return Ok(updateResult);
        }
    }
}