using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services.Interfaces;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetAllTask")]
        public Task<IEnumerable<TaskResponseModel>> GetAllTask()
        {
           return _taskService.GetAll();
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
            await _taskService.Add(task);
        }

        [HttpPut("UpdateTask")]
        public async Task UpdateTask(TaskRequestModel task, int idTask)
        {
            await _taskService.Update(task, idTask);
        }

        [HttpPost("DeleteTask")]
        public async Task DeleteTask(int idTask)
        {
            await _taskService.Delete(idTask);
        }
    }
}
