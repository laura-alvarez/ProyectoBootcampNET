using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet("GetAllTask")]
        public async Task<IEnumerable<TaskResponseModel>> GetAllTask()
        {                
            var taskList = await _taskService.GetAll();           
            return taskList;
        }

        [HttpGet("GetAllTaskByUserId")]
        public Task<IEnumerable<TaskResponseModel>> GetAllTaskByUserId(int userId) => _taskService.GetAllByUserId(userId);

        [HttpGet("GetTaskById")]
        public async Task GetTaskById(int idTask)
        {
            await _taskService.GetById(idTask);
        }

        [HttpPost("AddTask")]
        public async Task AddTask(TaskRequestModel task)
        {
            _logger.LogInformation("TaskController: AddTask - task added by user id " + task.UserId);
            await _taskService.Add(task);
        }

        [HttpPut("UpdateTask")]
        public async Task UpdateTask(TaskRequestModel task, int idTask)
        {
            _logger.LogInformation("TaskController: UpdateTask - task "+idTask+" updated by user id " + task.UserId);
            await _taskService.Update(task, idTask);
        }

        [HttpPost("DeleteTask")]
        public async Task DeleteTask(int idTask)
        {
            _logger.LogInformation("TaskController: DeleteTask - task " + idTask + " deleted");
            await _taskService.Delete(idTask);
        }
    }
}
