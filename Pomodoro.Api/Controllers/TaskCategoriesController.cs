using Microsoft.AspNetCore.Mvc;
using Pomodoro.Api.Contracts.Requests.Task;
using Pomodoro.Api.Contracts.Responses.Task;

namespace Pomodoro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCategoriesController : ControllerBase
    {
        private readonly ITaskCategoriesService _taskCategoriesService;

        public TaskCategoriesController(ITaskCategoriesService taskCategoriesService)
        {
            _taskCategoriesService = taskCategoriesService;
        }
        
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var catagories = _taskCategoriesService.GetAllTasks();

            return Ok(catagories);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateTaskCategoryRequest categoryRequest)
        {
            var newCategory = _taskCategoriesService.CreateCategory(categoryRequest);

            return Ok(newCategory);
        }

        [HttpPut]
        public IActionResult UpdateCategory(TaskCategoryRequest categoryRequest)
        {
            var updateResult = _taskCategoriesService.UpdateCategory(categoryRequest);

            return Ok(updateResult);
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int categoryId)
        {
            var deleteResult = _taskCategoriesService.DeleteCategory(categoryId);

            return Ok(deleteResult);
        }
    }

    public interface ITaskCategoriesService
    {
        List<TaskCategoryResponse> GetAllTasks();
        TaskCategoryResponse CreateCategory(CreateTaskCategoryRequest categoryRequest);
        bool UpdateCategory(TaskCategoryRequest categoryRequest);
        bool DeleteCategory(int categoryId);
    }
}
