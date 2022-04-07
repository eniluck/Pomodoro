using AutoMapper;

namespace Pomodoro.Api
{
    public class TaskCategoriesProfile: Profile
    {
        public TaskCategoriesProfile()
        {
            CreateMap<Core.Models.TaskCategory, Contracts.Responses.Task.TaskCategoryResponse>();
        }
    }
}
