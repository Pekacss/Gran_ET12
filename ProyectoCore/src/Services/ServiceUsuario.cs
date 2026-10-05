using System;
using System.Collections.Generic;
using BCrypt.Net;
using Repositories;
using Interfaces;
using Models;

namespace Services
{
    public class ServiceUsuario : IRepoUsuario
    {
        private readonly IRepoUsuario _repoUsuario;

        public ServiceUsuario(IRepoUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public Usuario Agregar(Usuario usuario)
        {
            if (!usuario.EsValido())
            {
                throw new ArgumentException("Faltan datos obligatorios del usuario.", nameof(usuario));
            }
            usuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña);
            // Un hash es una representación cifrada de la contraseña que no se puede revertir a su forma original sin conocer la contraseña original.
            // BCrypt genera un hash de 60 caracteres, pero al almacenarlo en un campo CHAR(64) se asegura de que haya suficiente espacio para cualquier variación futura del hash.
            return _repoUsuario.Agregar(usuario);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _repoUsuario.ObtenerTodos();
        }

        public Usuario? ObtenerPorId(ushort id)
        {
            return _repoUsuario.ObtenerPorId(id);
        }

        public Usuario? ObtenerPorEmail(string email)
        {
            return _repoUsuario.ObtenerPorEmail(email);
        }

        public Usuario? IniciarSesion(string email, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contraseña))
                return null;

            Usuario? usuario = _repoUsuario.ObtenerPorEmail(email);
            if (usuario == null || !usuario.EsValido() || !BCrypt.Net.BCrypt.Verify(contraseña, usuario.Contraseña))
                return null;

            return usuario;
        }

        public bool Eliminar(ushort id)
        {
            return _repoUsuario.Eliminar(id);
        }
    }
}
