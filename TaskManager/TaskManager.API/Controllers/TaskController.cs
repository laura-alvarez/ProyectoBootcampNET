using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Controllers
{
    /// <summary>
    /// Servicio de tareas
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todas las tareas
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllTask")]
        public async Task<IEnumerable<TaskResponseModel>> GetAllTask()
        {                
            var taskList = await _taskService.GetAll();           
            return taskList;
        }

        /// <summary>
        /// Obtiene todas las tareas asociadas a un usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("GetAllTaskByUserId")]
        public Task<IEnumerable<TaskResponseModel>> GetAllTaskByUserId(int userId) => _taskService.GetAllByUserId(userId);

        /// <summary>
        /// Obtiene los detalles de una tarea
        /// </summary>
        /// <param name="idTask"></param>
        /// <returns></returns>
        [HttpGet("GetTaskById")]
        public async Task GetTaskById(int idTask)
        {
            await _taskService.GetById(idTask);
        }

        /// <summary>
        /// Agrega una tarea nueva
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost("AddTask")]
        public async Task AddTask(TaskRequestModel task)
        {
            _logger.LogInformation("TaskController: AddTask - task added by user id " + task.UserId);
            await _taskService.Add(task);
        }

        /// <summary>
        /// Edita una tarea 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="idTask"></param>
        /// <returns></returns>
        [HttpPut("UpdateTask")]
        public async Task UpdateTask(TaskRequestModel task, int idTask)
        {
            _logger.LogInformation("TaskController: UpdateTask - task "+idTask+" updated by user id " + task.UserId);
            await _taskService.Update(task, idTask);
        }

        /// <summary>
        /// Elimina una tarea
        /// </summary>
        /// <param name="idTask"></param>
        /// <returns></returns>
        [HttpPost("DeleteTask")]
        public async Task DeleteTask(int idTask)
        {
            _logger.LogInformation("TaskController: DeleteTask - task " + idTask + " deleted");
            await _taskService.Delete(idTask);
        }
    }
}
