using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Repositories;
using Interfaces;
using Models;

namespace Services
{
    public class ServicePlantillaSuplente : IRepoPlantillaSuplente
    {
        private readonly IRepoPlantillaSuplente _repoPlantillaSuplente;

        public ServicePlantillaSuplente(IRepoPlantillaSuplente repoPlantillaSuplente)
        {
            _repoPlantillaSuplente = repoPlantillaSuplente;
        }

        public PlantillaSuplente Agregar(PlantillaSuplente plantillaSuplente)
        {
            if (plantillaSuplente.Id == 0)
            {
                throw new ArgumentException("El Id de la plantilla suplente debe ser distinto de 0.", nameof(plantillaSuplente));
            }
            if (plantillaSuplente.IdPlantilla == 0)
            {
                throw new ArgumentException("El IdPlantilla debe ser distinto de 0.", nameof(plantillaSuplente));
            }
            if (plantillaSuplente.IdJugador == 0)
            {
                throw new ArgumentException("El IdJugador debe ser distinto de 0.", nameof(plantillaSuplente));
            }
            return _repoPlantillaSuplente.Agregar(plantillaSuplente);
        }

        public List<PlantillaSuplente> ObtenerTodos()
        {
            return _repoPlantillaSuplente.ObtenerTodos();
        }

        public PlantillaSuplente? ObtenerPorId(int id)
        {
            return _repoPlantillaSuplente.ObtenerPorId(id);
        }

        public List<Jugador> ObtenerSuplentesPlantilla(int id)
        {
            return _repoPlantillaSuplente.ObtenerSuplentesPlantilla(id);
        }

        public bool Eliminar(int id)
        {
            return _repoPlantillaSuplente.Eliminar(id);
        }
    }
}
