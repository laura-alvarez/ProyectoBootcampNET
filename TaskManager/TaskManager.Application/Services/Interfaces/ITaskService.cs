using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Models.Users;

namespace TaskManager.Application.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponseModel>> GetAll();
        Task<IEnumerable<TaskResponseModel>> GetAllByUserId(int idUser);
        Task<TaskResponseModel> GetById(int id);
        Task Add(TaskRequestModel entity);
        Task Update(TaskRequestModel entity, int id);
        Task Delete(int id);
    }
}


