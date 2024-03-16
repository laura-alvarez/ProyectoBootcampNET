using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.Data.Data;

namespace TaskManager.Infrastructure.Data.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
