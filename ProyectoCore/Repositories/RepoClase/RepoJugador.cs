using System;
using System.Collections.Generic;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoJugador : IRepoJugador
    {
        public List<Jugador> ObtenerTodos()
        {
            throw new NotImplementedException("Falta conectar el repositorio real de jugadores.");
        }

        public Jugador? ObtenerPorId(ushort id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de jugadores.");
        }

        public Equipo? ObtenerEquipoPorJugador(ushort id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de jugadores.");
        }

        public Posicion? ObtenerPosicionPorJugador(ushort id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de jugadores.");
        }

        public Jugador Agregar(Jugador jugador)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de jugadores.");
        }
        
        public bool Eliminar(ushort id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de jugadores.");
            return false;
        }
    }
}