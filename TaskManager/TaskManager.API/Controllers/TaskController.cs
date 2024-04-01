using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services.Interfaces;

namespace TaskManager.API.Controllers
{
    /// <summary>
    /// Servicio de tareas
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Obtiene todas las tareas
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllTask")]
        public Task<IEnumerable<TaskResponseModel>> GetAllTask()
        {
           return _taskService.GetAll();
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
            await _taskService.Delete(idTask);
        }
    }
}
