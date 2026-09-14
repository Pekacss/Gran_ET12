using System;
using System.Collections.Generic;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoPlantillaTitular : IRepoPlantillaTitular
    {
        public List<PlantillaTitular> ObtenerTodos()
        {
            throw new NotImplementedException("Falta conectar el repositorio real de plantillas titulares.");
        }

        public PlantillaTitular? ObtenerPorId(int id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de plantillas titulares.");
        }

        public List<Jugador> ObtenerTitularesPlantilla(int id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de plantillas titulares.");
        }

        public PlantillaTitular Agregar(PlantillaTitular plantillaTitular)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de plantillas titulares.");
        }
        
        public bool Eliminar(int id)
        {
            throw new NotImplementedException("Falta conectar el repositorio real de plantillas titulares.");
            return false;
        }
    }
}