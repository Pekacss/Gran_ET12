using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            return_repoUsuario.Agregar(usuario);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _repoUsuario.ObtenerTodos();
        }

        public Usuario? ObtenerPorId(ushort id)
        {
            return _repoUsuario.ObtenerPorId(id);
        }

        public bool Eliminar(ushort id)
        {
            return _repoUsuario.Eliminar(id);
        }
    }
}
