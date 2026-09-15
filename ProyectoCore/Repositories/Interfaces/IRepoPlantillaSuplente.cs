using System;
using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepoPlantillaSuplente
    {
        List<PlantillaSuplente> ObtenerTodos();
        PlantillaSuplente? ObtenerPorId(int id);
        List<Jugador> ObtenerSuplentesPlantilla(int id);
        PlantillaSuplente Agregar(PlantillaSuplente plantillaSuplente);
        bool Eliminar(int id);
    }
}