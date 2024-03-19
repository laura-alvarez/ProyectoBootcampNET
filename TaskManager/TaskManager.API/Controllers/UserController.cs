using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services.Interfaces;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
           return _userService.GetAll();
        }

        [HttpPut("AddUser")]
        public async void AddTask(UserRequestModel user)
        {
            await _userService.Add(user);
        }
    }
}
