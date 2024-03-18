using AutoMapper;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskResponseModel>> GetAll()
        {
            var taskEntity = await _taskRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TaskResponseModel>>(taskEntity); ;
        }

        public async Task<IEnumerable<TaskResponseModel>> GetAllByUserId(int idUser)
        {
            var taskEntity = await _taskRepository.GetAllByUserIdAsync(idUser);

            return _mapper.Map<IEnumerable<TaskResponseModel>>(taskEntity); ;
        }

        public async Task<TaskResponseModel> GetById(int id)
        {
            var taskEntity = await Task.Run(() => _taskRepository.GetByIdSync(id));

            return _mapper.Map<TaskResponseModel>(taskEntity);
        }

        public async Task Add(TaskRequestModel entity)
        {
            var taskEntity = _mapper.Map<TaskEntity>(entity);
            taskEntity.CreatedBy = "Admin";
            taskEntity.UpdatedBy = "Admin";
            await _taskRepository.AddAsync(taskEntity);
            await _taskRepository.SaveChangesAsync();
        }

        public async Task Update(TaskRequestModel entity, int id)
        {
            TaskEntity TaskEntityFound = await _taskRepository.GetByIdAsync(id) ?? throw new Exception("La tarea no existe");

            var taskEntity = _mapper.Map(entity, TaskEntityFound);

            await _taskRepository.UpdateAsync(taskEntity);
            await _taskRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _taskRepository.DeleteAsync(id);
            await _taskRepository.SaveChangesAsync();
        }

    }
}
