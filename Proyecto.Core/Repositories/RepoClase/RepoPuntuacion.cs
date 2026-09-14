using System;
using System.Collections.Generic;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoPuntuacion : IRepoPuntuacion
    {
        public Puntuacion Agregar(Puntuacion puntuacion)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de puntuaciones.");
        }

        public List<Puntuacion> ObtenerTodos()
        {
            throw new NotImplementedException("Falta conectar el repositorio real de puntuaciones.");
        }

        public Puntuacion? ObtenerPorId(int id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de puntuaciones.");
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de puntuaciones.");
            return false;
        }
    }
}