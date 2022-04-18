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
    public class CategoriesController : ControllerBase
    {
        private readonly ITaskCategoriesService _taskCategoriesService;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(
            ILogger<CategoriesController> logger,
            IMapper mapper,
            ITaskCategoriesService taskCategoriesService)
        {
            _taskCategoriesService = taskCategoriesService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetCategoryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories()
        {
            var catagories = await _taskCategoriesService.GetAllTaskCategoriesAsync();

            return Ok(_mapper.Map<TaskCategory[], GetCategoryResponse[]>(catagories));
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetCategoryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest taskCategoryRequest)
        {
            var (newCategory, errors) = TaskCategory.Create(taskCategoryRequest.Name);
            if (errors.Any() || newCategory is null)
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(errors);
            }

            var createdCategory = await _taskCategoriesService.AddCategoryAsync(newCategory);

            return Ok(_mapper.Map<TaskCategory, GetCategoryResponse>(createdCategory));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCategory([FromRoute]int id, [FromBody]PutCategoryRequest categoryRequest)
        {
            var (newCategory, errors) = TaskCategory.Create(id, categoryRequest.Name);
            if (errors.Any() || newCategory is null)
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(errors);
            }

            var updateResult = await _taskCategoriesService.UpdateCategory(newCategory);

            return Ok(updateResult);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteCategory([FromRoute]int id)
        {
            var deleteResult = await _taskCategoriesService.DeleteCategory(id);

            return Ok(deleteResult);
        }
    }
}
