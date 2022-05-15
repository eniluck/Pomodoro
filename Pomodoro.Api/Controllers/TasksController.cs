using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Api.Contracts.Requests.Task;
using Pomodoro.Api.Contracts.Responses.Task;
using Pomodoro.Core;
using Pomodoro.Core.Models;

namespace Pomodoro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;
        private readonly IMapper _mapper;
        private readonly ILogger<TasksController> _logger;

        public TasksController(
            ILogger<TasksController> logger,
            IMapper mapper,
            ITasksService tasksService)
        {
            _tasksService = tasksService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetTaskResponse[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _tasksService.GetAllTasksAsync();

            return Ok(_mapper.Map<GetTaskResponse[]>(tasks));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TaskModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTask(CreateTaskRequest createTaskRequest)
        {
            var (newTask, errors) = TaskModel.Create(createTaskRequest.Name);
            if (errors.Any() || newTask is null)
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(errors);
            }

            var createdTask = await _tasksService.CreateTaskAsync(newTask, createTaskRequest.CategoryId);
            if (createdTask.Errors.Any() || createdTask.Result is null)
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(createdTask.Errors);
            }

            return Ok(createdTask.Result);
        }

        [HttpPut("{id:int}")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTask([FromRoute]int taskId, [FromBody]UpdateTaskRequest updateTaskRequest)
        {
            var (updateTask, errors) = TaskModel.Create(
                taskId,
                updateTaskRequest.Name,
                null,
                updateTaskRequest.Status,
                updateTaskRequest.PomodoroEstimation);

            if (errors.Any() || updateTask is null)
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(errors);
            }

            var updateResult = await _tasksService.UpdateTaskAsync(updateTask, updateTaskRequest.CategoryId);

            if (updateResult.Errors.Any())
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(updateResult.Errors);
            }

            return Ok(updateResult.Result);
        }

        [HttpDelete("{taskId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteTask([FromRoute] int taskId)
        {
            //TODO: Может возвращать Task ? и выполнение операции гарантирует что объект удалён?
            var deleteResult = await _tasksService.DeleteTaskAsync(taskId);

            return Ok(deleteResult);
        }
    }
}