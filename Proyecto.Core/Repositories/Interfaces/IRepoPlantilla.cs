using System;
using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepoPlantilla
    {
        List<Plantilla> ObtenerTodos();
        Plantilla? ObtenerPorId(int id);
        List<Jugador> ObtenerJugadoresPorPlantilla(int id);
        float ObtenerCalificacionPlantilla(int id);
        Plantilla Agregar(Plantilla plantilla);
        bool Eliminar(int id);
    }
}