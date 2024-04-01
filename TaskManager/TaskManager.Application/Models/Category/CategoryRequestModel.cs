using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Models.Users
{
    public class CategoryRequestModel
    {
        /// <summary>
        /// Nombre de la categoría
        /// </summary>
        public string Category { get; set; }        

    }
}
