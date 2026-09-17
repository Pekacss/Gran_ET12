using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Repositories;
using Interfaces;
using Models;

namespace Services
{
    public class ServiceEquipo : IRepoEquipo
    {
        private readonly IRepoEquipo _repoEquipo;

        public ServiceEquipo(IRepoEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }

        public Equipo Agregar(Equipo equipo)
        {
            return _repoEquipo.Agregar(equipo);
        }

        public List<Equipo> ObtenerTodos()
        {
            return _repoEquipo.ObtenerTodos();
        }

        public Equipo? ObtenerPorId(byte id)
        {
            return _repoEquipo.ObtenerPorId(id);
        }

        public bool Eliminar(byte id)
        {
            return _repoEquipo.Eliminar(id);
        }

        public List<Jugador> ObtenerJugadoresPorEquipo(byte id)
        {
            return _repoEquipo.ObtenerJugadoresPorEquipo(id);
        }
    }
}
