using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class TaskEntity:BaseEntity
    {
        public int Id { get; set; }        
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

        public virtual UserEntity User { get; set; } = new UserEntity();
        public int UserId { get; set; }

        public virtual CategoryEntity Category { get; set; } = new CategoryEntity();
        public int CategoryId { get; set; }

        public virtual StateEntity State { get; set; } = new StateEntity();
        public int StateId { get; set; }

    }
}
