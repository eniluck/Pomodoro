using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Api.Contracts.Requests.Task;
using Pomodoro.Api.Contracts.Responses;
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

        public TasksController(ITasksService tasksService, IMapper mapper)
        {
            _tasksService = tasksService;
            _mapper = mapper;
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
            var taskRequest = _mapper.Map<TaskModel>(createTaskRequest);
            var newTask = _tasksService.CreateTask(taskRequest);

            return Ok(_mapper.Map<TaskResponse>(newTask));
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