using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services.Interfaces;
using static TaskManager.Client.Data.Dtos.ServiceResponses;

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

        [HttpGet("GetUser")]
        public Task<UserResponseModel> GetUser(int idUser)
        {
            return _userService.GetById(idUser);
        }

        [HttpPost("AddUser")]
        public async Task AddTask(UserRequestModel user)
        {
            await _userService.Add(user);
        }

        [HttpPut("UpdateUser")]
        public async Task UpdateUser(UserRequestModel user, int idUser)
        {
            await _userService.Update(user, idUser);
        }

        [HttpDelete("DeleteUser")]
        public async Task DeleteUser(int idUser)
        {
            await _userService.Delete(idUser);
        }

        [HttpGet("CheckUser")]
        public async Task<LoginResponse> CheckUser(string email, string password)
        { 
            return await _userService.CheckUser(email, password);        
        }
    }
}
