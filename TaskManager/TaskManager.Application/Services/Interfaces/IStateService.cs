using TaskManager.Application.Models.Users;

namespace TaskManager.Application.Services.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<StateResponseModel>> GetAll();
        Task<StateResponseModel> GetById(int id);
        Task Add(StateRequestModel entity);
        Task Update(StateRequestModel entity, int id);
        Task Delete(int id);
    }
}


