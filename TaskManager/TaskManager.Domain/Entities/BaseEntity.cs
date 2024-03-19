using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{ 
   public class BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

        public int? CreatedBy { get; set; }
        public UserEntity? UserCreate { get; set; }
        public int? UpdatedBy { get; set; }
        public UserEntity? UserUpdate { get; set; }
    }
}
