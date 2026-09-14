using System;
using System.Collections.Generic;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoPlantilla : IRepoPlantilla
    {
        public List<Plantilla> ObtenerTodos()
        {
            throw new NotImplementedException("Falta conectar el repositorio real de plantillas.");
        }

        public Plantilla? ObtenerPorId(int id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de plantillas.");
        }

        public List<Jugador> ObtenerJugadoresPorPlantilla(int id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de plantillas.");
        }

        public float ObtenerCalificacionPlantilla(int id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de plantillas.");
        }

        public Plantilla Agregar(Plantilla plantilla)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de plantillas.");
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de plantillas.");
            return false;
        }
    }
}