using System;
namespace Models
{
    public class Usuario
    {
        public ushort Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; } = DateTime.MinValue;
        public string Contraseña { get; set; } = string.Empty;
    }
}

