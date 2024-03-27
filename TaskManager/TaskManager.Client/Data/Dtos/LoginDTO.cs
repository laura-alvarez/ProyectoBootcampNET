using System.ComponentModel.DataAnnotations;


namespace TaskManager.Client.Data.Dtos
{
    public class LoginDTO
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, introduzca su email")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, introduzca la contraseña")]
        public string? Password { get; set; }
      
    }
}
