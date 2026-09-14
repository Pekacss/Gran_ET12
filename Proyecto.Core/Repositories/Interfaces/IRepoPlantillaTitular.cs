using System;
using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepoPlantillaTitular
    {
        List<PlantillaTitular> ObtenerTodos();
        PlantillaTitular? ObtenerPorId(int id);
        List<Jugador> ObtenerTitularesPlantilla(int id);
        PlantillaTitular Agregar(PlantillaTitular plantillaTitular);
        bool Eliminar(int id);
    }
}