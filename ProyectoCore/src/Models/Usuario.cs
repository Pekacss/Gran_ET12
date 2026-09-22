namespace Models
{
    public class Usuario
    {
        public ushort Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; } = DateTime.MinValue;
        public bool Administrador { get; set; } = false;
        public string Contraseña { get; set; } = string.Empty;

        public bool EsValido()
        {
            return !string.IsNullOrWhiteSpace(Nombre)
                && !string.IsNullOrWhiteSpace(Apellido)
                && !string.IsNullOrWhiteSpace(Email)
                && FechaNacimiento != DateTime.MinValue
                && Contraseña.Length == 64;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellido))
            {
                throw new ArgumentException("El usuario debe tener nombre y apellido.");
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                throw new ArgumentException("El usuario debe tener email.");
            }
            if (FechaNacimiento == DateTime.MinValue)
            {
                throw new ArgumentException("El usuario debe tener fecha de nacimiento.");
            }
            if (Contraseña.Length != 64)
            {
                throw new ArgumentException("La contraseña almacenada debe tener exactamente 64 caracteres.", nameof(Contraseña));
            }
        }

        public void ValidarAdministrador()
        {
            if (!Administrador)
            {
                throw new ArgumentException("El usuario debe ser administrador.");
            }
        }

        public bool EsAdministrador()
        {
            return Administrador;
        }
    }
}

