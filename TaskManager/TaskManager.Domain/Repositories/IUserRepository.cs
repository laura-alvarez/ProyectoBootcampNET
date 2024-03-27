using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity? CheckUser(string email, string password);
    }


}
