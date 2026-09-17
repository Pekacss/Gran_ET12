using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Repositories;
using Interfaces;
using Models;

namespace Services
{
    public class ServiceJugador : IRepoJugador
    {
        private readonly IRepoJugador _repoJugador;

        public ServiceJugador(IRepoJugador repoJugador)
        {
            _repoJugador = repoJugador;
        }

        public Jugador Agregar(Jugador jugador)
        {
            return _repoJugador.Agregar(jugador);
        }

        public List<Jugador> ObtenerTodos()
        {
            return _repoJugador.ObtenerTodos();
        }

        public Jugador? ObtenerPorId(ushort id)
        {
            return _repoJugador.ObtenerPorId(id);
        }

        public Equipo? ObtenerEquipoPorJugador(ushort id)
        {
            return _repoJugador.ObtenerEquipoPorJugador(id);
        }

        public Posicion? ObtenerPosicionPorJugador(ushort id)
        {
            return _repoJugador.ObtenerPosicionPorJugador(id);
        }

        public bool Eliminar(ushort id)
        {
            return _repoJugador.Eliminar(id);
        }
    }
}
