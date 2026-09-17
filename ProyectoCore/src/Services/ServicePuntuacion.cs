using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Repositories;
using Interfaces;
using Models;

namespace Services
{
    public class ServicePuntuacion : IRepoPuntuacion
    {
        private readonly IRepoPuntuacion _repoPuntuacion;

        public ServicePuntuacion(IRepoPuntuacion repoPuntuacion)
        {
            _repoPuntuacion = repoPuntuacion;
        }

        public Puntuacion Agregar(Puntuacion puntuacion)
        {
            return _repoPuntuacion.Agregar(puntuacion);
        }

        public List<Puntuacion> ObtenerTodos()
        {
            return _repoPuntuacion.ObtenerTodos();
        }

        public List<Puntuacion?> ObtenerPorFecha(byte fecha)
        {
            return _repoPuntuacion.ObtenerPorFecha(fecha);
        }

        public List<Puntuacion?> ObtenerPorJugador(ushort id)
        {
            return _repoPuntuacion.ObtenerPorJugador(id);
        }

        public Puntuacion? ObtenerPorFechaJugador(byte fecha, ushort id)
        {
            return _repoPuntuacion.ObtenerPorFechaJugador(fecha, id);
        }

        public bool Eliminar(int id)
        {
            return _repoPuntuacion.Eliminar(id);
        }
    }
}
