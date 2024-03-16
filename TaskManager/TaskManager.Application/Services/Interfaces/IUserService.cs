using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Models.Users;

namespace TaskManager.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseModel>> GetAll();
        Task<UserResponseModel> GetById(int id);
        Task Add(UserRequestModel entity);
        Task Update(UserRequestModel entity, int id);
        Task Delete(int id);
    }
}
