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
            CreateMap<TaskModel, GetTaskResponse>();
            CreateMap<GetTaskResponse, TaskModel>();
        }
    }
}
