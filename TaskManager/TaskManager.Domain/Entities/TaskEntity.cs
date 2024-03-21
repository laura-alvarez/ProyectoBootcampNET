﻿using System;
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

        public CategoryEntity? Category { get; set; }
        public int? CategoryId { get; set; }

        public StateEntity? State { get; set; }
        public int? StateId { get; set; }

    }
}