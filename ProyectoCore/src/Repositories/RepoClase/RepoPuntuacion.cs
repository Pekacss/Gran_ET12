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

        public List<Puntuacion?> ObtenerPorFecha(byte fecha)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de puntuaciones.");
        }

        public List<Puntuacion?> ObtenerPorJugador(ushort id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de puntuaciones.");
        }

        public Puntuacion? ObtenerPorFechaJugador(byte fecha, ushort id)
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