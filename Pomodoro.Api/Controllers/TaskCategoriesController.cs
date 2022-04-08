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

        public TaskCategoriesController(ITaskCategoriesService taskCategoriesService, IMapper mapper)
        {
            _taskCategoriesService = taskCategoriesService;
            _mapper = mapper;
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
        public async Task<IActionResult> AddCategory(CreateTaskCategoryRequest categoryRequest)
        {
            var request = _mapper.Map<TaskCategory>(categoryRequest);
            var newCategory = await _taskCategoriesService.AddCategoryAsync(request);

            return Ok(_mapper.Map<TaskCategoryResponse>(newCategory));
        }

        [HttpPut("UpdateCategory")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCategory(TaskCategoryRequest categoryRequest)
        {
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
