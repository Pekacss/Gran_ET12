using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Repositories;
using Interfaces;
using Models;

namespace Services
{
    public class ServicePosicion : IRepoPosicion
    {
        private readonly IRepoPosicion _repoPosicion;

        public ServicePosicion(IRepoPosicion repoPosicion)
        {
            _repoPosicion = repoPosicion;
        }

        public Posicion Agregar(Posicion posicion)
        {
            return _repoPosicion.Agregar(posicion);
        }

        public List<Posicion> ObtenerTodos()
        {
            return _repoPosicion.ObtenerTodos();
        }

        public Posicion? ObtenerPorId(ushort id)
        {
            return _repoPosicion.ObtenerPorId(id);
        }

        public List<Jugador> ObtenerJugadoresPorPosicion(ushort id)
        {
            return _repoPosicion.ObtenerJugadoresPorPosicion(id);
        }

        public bool Eliminar(byte id)
        {
            return _repoPosicion.Eliminar(id);
        }
    }
}
