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

        public bool CheckUser(string email, string password)
        {            
           return _context.Set<UserEntity>().Where(user => user.Email == email && user.Password == password).Any();        
        }
    }
}
