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
            CreateMap<TaskCategory, CategoryResponse>();
            CreateMap<CreateCategoryRequest, TaskCategory>();
            CreateMap<PutCategoryRequest, TaskCategory>();

            CreateMap<TaskModel, TaskResponse>();
            CreateMap<CreateTaskRequest, TaskModel>();
            CreateMap<PutTaskRequest, TaskModel>();

            CreateMap<TaskResponse, TaskModel>();
        }
    }
}
