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
    public class TaskCategoriesController : ControllerBase
    {
        private readonly ITaskCategoriesService _taskCategoriesService;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskCategoriesController> _logger;

        public TaskCategoriesController(ILogger<TaskCategoriesController> logger, IMapper mapper, ITaskCategoriesService taskCategoriesService)
        {
            _taskCategoriesService = taskCategoriesService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAllCategories")]
        [ProducesResponseType(typeof(List<TaskCategoryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories()
        {
            var catagories = await _taskCategoriesService.GetAllTaskCategoriesAsync();

            return Ok(_mapper.Map<List<TaskCategoryResponse>>(catagories));
        }

        [HttpPost("AddCategory")]
        [ProducesResponseType(typeof(TaskCategoryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddCategory(CreateTaskCategoryRequest taskCategoryRequest)
        {
            var (newCategory, errors) = TaskCategory.Create(taskCategoryRequest.Name);
            if (errors.Any() || newCategory is null)
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(errors);
            }

            var createdCategory = await _taskCategoriesService.AddCategoryAsync(newCategory);

            return Ok(_mapper.Map<TaskCategoryResponse>(createdCategory));
        }

        [HttpPut("UpdateCategory")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCategory(TaskCategoryRequest categoryRequest)
        {
            var (newCategory, errors) = TaskCategory.Create(categoryRequest.Id, categoryRequest.Name);
            if (errors.Any() || newCategory is null)
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(errors);
            }

            var request = _mapper.Map<TaskCategory>(categoryRequest);
            var updateResult = await _taskCategoriesService.UpdateCategory(request);

            return Ok(updateResult);
        }

        [HttpDelete("DeleteCategory")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var deleteResult = await _taskCategoriesService.DeleteCategory(categoryId);

            return Ok(deleteResult);
        }
    }
}
