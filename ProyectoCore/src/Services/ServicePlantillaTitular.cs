using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Repositories;
using Interfaces;
using Models;

namespace Services
{
    public class ServicePlantillaTitular : IRepoPlantillaTitular
    {
        private readonly IRepoPlantillaTitular _repoPlantillaTitular;

        public ServicePlantillaTitular(IRepoPlantillaTitular repoPlantillaTitular)
        {
            _repoPlantillaTitular = repoPlantillaTitular;
        }

        public PlantillaTitular Agregar(PlantillaTitular plantillaTitular)
        {
            if (plantillaTitular.Id == 0)
            {
                throw new ArgumentException("El Id de la plantilla titular debe ser distinto de 0.", nameof(plantillaTitular));
            }
            if (plantillaTitular.IdPlantilla == 0)
            {
                throw new ArgumentException("El IdPlantilla debe ser distinto de 0.", nameof(plantillaTitular));
            }
            if (plantillaTitular.IdJugador == 0)
            {
                throw new ArgumentException("El IdJugador debe ser distinto de 0.", nameof(plantillaTitular));
            }
            return _repoPlantillaTitular.Agregar(plantillaTitular);
        }

        public List<PlantillaTitular> ObtenerTodos()
        {
            return _repoPlantillaTitular.ObtenerTodos();
        }

        public PlantillaTitular? ObtenerPorId(int id)
        {
            return _repoPlantillaTitular.ObtenerPorId(id);
        }

        public List<Jugador> ObtenerTitularesPlantilla(int id)
        {
            return _repoPlantillaTitular.ObtenerTitularesPlantilla(id);
        }

        public bool Eliminar(int id)
        {
            return _repoPlantillaTitular.Eliminar(id);
        }
    }
}
