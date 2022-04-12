using AutoMapper;
using Pomodoro.Api.Contracts.Requests.Task;
using Pomodoro.Api.Contracts.Responses.Task;
using Pomodoro.Core.Models;

namespace Pomodoro.Api
{
    public class MappingProfle : Profile
    {
        public MappingProfle()
        {
            CreateMap<TaskCategory, TaskCategoryResponse>();
            CreateMap<CreateTaskCategoryRequest, TaskCategory>();
            CreateMap<TaskCategoryRequest, TaskCategory>();

            CreateMap<TaskModel, TaskResponse>();
            CreateMap<CreateTaskRequest, TaskModel>();
            CreateMap<UpdateTaskRequest, TaskModel>();

            CreateMap<TaskResponse, TaskModel>();
        }
    }
}
