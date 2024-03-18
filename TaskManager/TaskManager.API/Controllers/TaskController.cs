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
        //public IEnumerable<TaskResponseModel> GetAllTask() => (IEnumerable<TaskResponseModel>)_taskService.GetAll();
        public Task<IEnumerable<TaskResponseModel>> GetAllTask()
        {
           return _taskService.GetAll();
        }

        [HttpGet("GetAllTaskByUserId")]
        public Task<IEnumerable<TaskResponseModel>> GetAllTaskByUserId(int userId) => _taskService.GetAllByUserId(userId);
    }
}
