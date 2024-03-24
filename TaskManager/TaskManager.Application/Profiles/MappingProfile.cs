using AutoMapper;
using TaskManager.Application.Models.Users;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserResponseModel>();
            CreateMap<UserRequestModel, UserEntity>();

            CreateMap<TaskEntity, TaskResponseModel>();
            CreateMap<TaskRequestModel, TaskEntity>();

            CreateMap<CategoryEntity, CategoryResponseModel>();
            CreateMap<CategoryRequestModel, CategoryEntity>();

            CreateMap<StateEntity, StateResponseModel>();
            CreateMap<StateRequestModel, StateEntity>();
        }
    }
}
