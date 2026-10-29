using System;
using Models;
namespace dto
{
    public class UsuarioPostDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; } = DateOnly.MinValue;
        public bool EsAdmin { get; set; } = false;
        public string Contraseña { get; set; } = string.Empty;

        public UsuarioPostDTO() { }

        public Usuario AModelo()
        {
            return new Usuario
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Email = Email,
                FechaNacimiento = FechaNacimiento.ToDateTime(TimeOnly.MinValue),
                Administrador = EsAdmin,
                Contraseña = Contraseña
            };
        }

        public UsuarioPostDTO(Usuario usuario)
        {
            Nombre = usuario.Nombre;
            Apellido = usuario.Apellido;
            Email = usuario.Email;
            FechaNacimiento = DateOnly.FromDateTime(usuario.FechaNacimiento);
            EsAdmin = usuario.Administrador;
            Contraseña = usuario.Contraseña;
        }
    }

    public class UsuarioLoginDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;

        public UsuarioLoginDTO() { }

        public UsuarioLoginDTO(Usuario usuario)
        {
            Email = usuario.Email;
            Contraseña = usuario.Contraseña;
        }
    }

    public class UsuarioGetDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; } = DateOnly.MinValue;
        public bool EsAdmin { get; set; } = false;

        public UsuarioGetDTO(Usuario usuario)
        {
            Nombre = usuario.Nombre;
            Apellido = usuario.Apellido;
            Email = usuario.Email;
            FechaNacimiento = DateOnly.FromDateTime(usuario.FechaNacimiento);
            EsAdmin = usuario.Administrador;
        }
    }
}
