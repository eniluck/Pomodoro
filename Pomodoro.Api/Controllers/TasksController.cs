using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Api.Contracts.Requests.Task;
using Pomodoro.Api.Contracts.Responses;
using Pomodoro.Core;
using Pomodoro.Core.Models;
using System.Linq;

namespace Pomodoro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;
        private readonly IMapper _mapper;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger, IMapper mapper)//, ITasksService tasksService)
        {
           // _tasksService = tasksService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _tasksService.GetAllTasks();

            return Ok(_mapper.Map<List<TaskResponse>>(tasks));
        }

        [HttpPost]
        public IActionResult CreateTask(CreateTaskRequest createTaskRequest)
        {
            var (newTask, errors) = TaskModel.Create(createTaskRequest.Name);
            if (errors.Any() || newTask is null)
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(errors);
            }

            //var createdTask = _tasksService.CreateTask(newTask);

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
            var taskRequest = _mapper.Map<TaskModel>(updateTaskRequest);
            var updateResult = _tasksService.UpdateTask(taskRequest);

            return Ok(updateResult);
        }
    }
}