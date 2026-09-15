using System;
using System.Collections.Generic;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoEquipo : IRepoEquipo
    {
        public List<Equipo> ObtenerTodos()
        {
            throw new NotImplementedException("Falta conectar el repositorio real de equipos.");
        }

        public Equipo? ObtenerPorId(ushort id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de equipos.");
        }

        public List<Jugador> ObtenerJugadoresPorEquipo(ushort id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de equipos.");
        }

        public Equipo Agregar(Equipo equipo)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de equipos.");
        }

        public bool Eliminar(ushort id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de equipos.");
            return false;
        }
    }
}