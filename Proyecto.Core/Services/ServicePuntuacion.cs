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

        public Puntuacion? ObtenerPorId(int id)
        {
            return _repoPuntuacion.ObtenerPorId(id);
        }

        public bool Eliminar(int id)
        {
            return _repoPuntuacion.Eliminar(id);
        }
    }
}
