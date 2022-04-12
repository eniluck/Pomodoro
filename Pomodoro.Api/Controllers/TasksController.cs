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
        private readonly ITaskCategoriesService _taskCategoriesService;
        private readonly IMapper _mapper;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger, IMapper mapper, ITasksService tasksService, ITaskCategoriesService taskCategoriesService)
        {
            _tasksService = tasksService;
            _taskCategoriesService = taskCategoriesService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _tasksService.GetAllTasksAsync();

            return Ok(_mapper.Map<List<TaskResponse>>(tasks));
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(CreateTaskRequest createTaskRequest)
        {
            TaskCategory? existedCategory = null;

            if (createTaskRequest.CategoryId is not null)
            {
                existedCategory = await _taskCategoriesService.GetAsync(createTaskRequest.CategoryId.Value);

                if (existedCategory is null)
                {
                    var error = new string[] { "Не найдена категория по Id" };
                    _logger.LogError("{errors}", error);
                    return BadRequest(error);
                }
            }

            var (newTask, errors) = TaskModel.Create(createTaskRequest.Name, existedCategory);
            if (errors.Any() || newTask is null)
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(errors);
            }

            var createdTask = await _tasksService.CreateTaskAsync(newTask);

            return Ok(createdTask);
        }

        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var deleteResult = await _tasksService.DeleteTaskAsync(taskId);

            return Ok(deleteResult);
        }

        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(UpdateTaskRequest updateTaskRequest)
        {
            TaskCategory? existedCategory = null;

            if (updateTaskRequest.CategoryId is not null)
            {
                existedCategory = await _taskCategoriesService.GetAsync(updateTaskRequest.CategoryId.Value);

                if (existedCategory is null)
                {
                    var error = new string[] { "Не найдена категория по Id" };
                    _logger.LogError("{errors}", error);
                    return BadRequest(error);
                }
            }

            var (updateTask, errors) = TaskModel.Create(
                updateTaskRequest.Id,
                updateTaskRequest.Name,
                existedCategory,
                (TaskStatusModel)updateTaskRequest.Status,
                updateTaskRequest.PomodoroEstimation);

            if (errors.Any() || updateTask is null)
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(errors);
            }

            var updateResult = await _tasksService.UpdateTaskAsync(updateTask);

            return Ok(updateResult);
        }
    }
}