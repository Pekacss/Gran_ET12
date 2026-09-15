using System;
using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepoUsuario
    {
        List<Usuario> ObtenerTodos();
        Usuario? ObtenerPorId(ushort id);
        Usuario Agregar(Usuario usuario);
        bool Eliminar(ushort id);

    }
}