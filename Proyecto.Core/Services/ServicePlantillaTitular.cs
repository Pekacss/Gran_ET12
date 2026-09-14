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
