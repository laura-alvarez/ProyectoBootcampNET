using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.Data.Dtos
{
    public class SesionDTO
    {
        public required string Nombre { get; set; }
        public required string Correo { get; set; }
        //public bool Rol { get; set; }
    }
}
