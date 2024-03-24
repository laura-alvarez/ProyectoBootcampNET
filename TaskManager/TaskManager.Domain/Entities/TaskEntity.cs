using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class TaskEntity:DatesControlEntity
    {
        public int Id { get; set; }        
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

        public UserEntity User { get; set; }
        public int UserId { get; set; }

        public CategoryEntity Category { get; set; }
        public int CategoryId { get; set; }

        public StateEntity State { get; set; }
        public int StateId { get; set; }

    }
}
