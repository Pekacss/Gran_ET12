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

        public Equipo? ObtenerPorId(byte id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de equipos.");
        }

        public List<Jugador> ObtenerJugadoresPorEquipo(byte id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de equipos.");
        }

        public Equipo Agregar(Equipo equipo)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de equipos.");
        }

        public bool Eliminar(byte id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de equipos.");
            return false;
        }
    }
}