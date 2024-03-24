using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class CategoryEntity: LogicDeleteEntity
    {
        public int Id { get; set; }
        public string Category { get; set; }
    }
}
