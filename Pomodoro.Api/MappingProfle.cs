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
            CreateMap<TaskCategory, GetCategoryResponse>();
            CreateMap<CreateCategoryRequest, TaskCategory>();
            CreateMap<PutCategoryRequest, TaskCategory>();

            CreateMap<TaskModel, GetTaskResponse>();
            CreateMap<CreateTaskRequest, TaskModel>();
            CreateMap<PutTaskRequest, TaskModel>();

            CreateMap<GetTaskResponse, TaskModel>();
        }
    }
}
