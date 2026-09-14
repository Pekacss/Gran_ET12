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

        public Equipo? ObtenerEquipoPorjugador(ushort id)
        {
            return _repoJugador.ObtenerEquipoPorjugador(id);
        }

        public Posicion? ObtenerPosicionPorjugador(ushort id)
        {
            return _repoJugador.ObtenerPosicionPorjugador(id);
        }

        public bool Eliminar(ushort id)
        {
            return _repoJugador.Eliminar(id);
        }
    }
}
