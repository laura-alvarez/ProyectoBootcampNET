using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Models.Users
{
    public class TaskResponseModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int StateId { get; set; }
    }
}
