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
        
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var catagories = _taskCategoriesService.GetAllTaskCategories();

            return Ok(_mapper.Map<List<TaskCategoryResponse>>(catagories));
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateTaskCategoryRequest categoryRequest)
        {
            var request = _mapper.Map<TaskCategory>(categoryRequest);
            var newCategory = _taskCategoriesService.CreateCategory(request);

            return Ok(_mapper.Map<TaskCategoryResponse>(newCategory));
        }

        [HttpPut]
        public IActionResult UpdateCategory(TaskCategoryRequest categoryRequest)
        {
            var request = _mapper.Map<TaskCategory>(categoryRequest);
            var updateResult = _taskCategoriesService.UpdateCategory(request);

            return Ok(_mapper.Map<TaskCategoryResponse>(updateResult));
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int categoryId)
        {
            var deleteResult = _taskCategoriesService.DeleteCategory(categoryId);

            return Ok(deleteResult);
        }
    }
}
