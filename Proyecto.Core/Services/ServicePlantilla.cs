using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Repositories;
using Interfaces;
using Models;

namespace Services
{
    public class ServicePlantilla : IRepoPlantilla
    {
        private readonly IRepoPlantilla _repoPlantilla;

        public ServicePlantilla(IRepoPlantilla repoPlantilla)
        {
            _repoPlantilla = repoPlantilla;
        }

        public Plantilla Agregar(Plantilla plantilla)
        {
            return _repoPlantilla.Agregar(plantilla);
        }

        public List<Plantilla> ObtenerTodos()
        {
            return _repoPlantilla.ObtenerTodos();
        }

        public Plantilla? ObtenerPorId(ushort id)
        {
            return _repoPlantilla.ObtenerPorId(id);
        }

        public List<Jugador> ObtenerJugadoresPorPlantilla(ushort id)
        {
            return _repoPlantilla.ObtenerJugadoresPorPlantilla(id);
        }

        public float ObtenerCalificacionPlantilla(ushort id)
        {
            return _repoPlantilla.ObtenerCalificacionPlantilla(id);
        }

        public bool Eliminar(ushort id)
        {
            return _repoPlantilla.Eliminar(id);
        }
    }
}
