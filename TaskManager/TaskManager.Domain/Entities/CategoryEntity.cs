using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Category { get; set; }

        public ICollection<TaskEntity> Task { get; set; }
    }
}
