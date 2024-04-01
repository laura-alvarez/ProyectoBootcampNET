using System.ComponentModel.DataAnnotations;

namespace TaskManager.Client.Data.Dtos
{
    public class TaskDTO
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, introduzca un título")]
        public string? Titulo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, introduzca una descripción")]
        public string? Descripcion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, seleccione un tipo de tarea")]
        public string? Tipo { get; set; }
        public string? Estado { get; set; }
        public string? TipoName { get; set; }
    }
}
