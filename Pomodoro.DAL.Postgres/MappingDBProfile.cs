using AutoMapper;
using Pomodoro.Core.Models;
using Pomodoro.DAL.Postgres.Entities;

namespace Pomodoro.DAL.Postgres
{
    public class MappingDBProfile : Profile
    {
        public MappingDBProfile()
        {
            CreateMap<TaskCategoryEntity, TaskCategory>();
            CreateMap<TaskCategory, TaskCategoryEntity>();
        }
    }
}
