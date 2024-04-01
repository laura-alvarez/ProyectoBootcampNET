using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services.Interfaces;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        /// <summary>
        /// Obtiene todos los estados
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllStates")]
        public Task<IEnumerable<StateResponseModel>> GetAllStates() { 
            return _stateService.GetAll();
        }

        /// <summary>
        /// Obtiene un estado
        /// </summary>
        /// <param name="idState"></param>
        /// <returns></returns>
        [HttpGet("GetState")]
        public async Task<StateResponseModel> GetState(int idState)
        {
            return await _stateService.GetById(idState);
        }

        /// <summary>
        /// Agrega un estado nuevo
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpPost("AddState")]
        public async Task AddState(StateRequestModel state)
        {
            await _stateService.Add(state);
        }

        /// <summary>
        /// Actualiza un estado
        /// </summary>
        /// <param name="state"></param>
        /// <param name="idState"></param>
        /// <returns></returns>
        [HttpPut("UpdateState")]
        public async Task UpdateState(StateRequestModel state, int idState)
        {
            await _stateService.Update(state, idState);
        }


        /// <summary>
        /// Elimina un estado
        /// </summary>
        /// <param name="idState"></param>
        /// <returns></returns>
        [HttpDelete("DeleteState")]
        public async Task DeleteState(int idState)
        {
            await _stateService.Delete(idState);
        }
    }
}
