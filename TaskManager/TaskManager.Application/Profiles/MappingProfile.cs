using AutoMapper;
using TaskManager.Application.Models.Users;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskEntity, TaskResponseModel>();
            CreateMap<TaskRequestModel, TaskEntity>();
            // Agrega más configuraciones de mapeo aquí si es necesario
        }
    }
}
