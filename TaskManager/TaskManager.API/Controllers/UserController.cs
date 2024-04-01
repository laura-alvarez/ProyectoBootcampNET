using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene un listado de usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllUsers")]
        [Authorize]
        public Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
           return _userService.GetAll();
        }

        /// <summary>
        /// Obtiene la información de un usuario
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("GetUser")]
        [Authorize]
        public Task<UserResponseModel> GetUser(int idUser)
        {
            return _userService.GetById(idUser);
        }

        /// <summary>
        /// Agrega un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public async Task AddUser(UserRequestModel user)
        {
            _logger.LogInformation("UserController: AddUser - " + " user added");
            await _userService.Add(user);
        }

        /// <summary>
        /// Actualiza un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpPut("UpdateUser")]
        [Authorize]
        public async Task UpdateUser(UserRequestModel user, int idUser)
        {
            _logger.LogInformation("UserController: UpdateUser - " + " user id " + idUser + " updated");
            await _userService.Update(user, idUser);
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUser")]
        [Authorize]
        public async Task DeleteUser(int idUser)
        {
            _logger.LogInformation("UserController: DeleteUser - " + " user id " + idUser + " deleted");
            await _userService.Delete(idUser);
        }

        /// <summary>
        /// Comprueba que los datos enviados son correctos
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("CheckUser")]
        public async Task<LoginResponse> CheckUser(string email, string password)
        {
            var result = await _userService.CheckUser(email, password);
            _logger.LogInformation("UserController: CheckUser - " + email + "- Result:"+(result.Flag?" Check succesful":"Check failled"));
            return result;
        }
    }
}
