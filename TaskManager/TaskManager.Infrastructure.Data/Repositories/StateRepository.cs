using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.Data.Data;

namespace TaskManager.Infrastructure.Data.Repositories
{
    public class StateRepository : GenericRepository<StateEntity>, IStateRepository
    {
        public StateRepository(DataContext context) : base(context)
        {
        }
    }
}
