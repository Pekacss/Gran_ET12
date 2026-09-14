using System;
using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepoPuntuacion
    {
        List<Puntuacion> ObtenerTodos();
        Puntuacion? ObtenerPorId(int id);
        float ObtenerCalificacionPuntuacion(int id);
        Puntuacion Agregar(Puntuacion puntuacion);
        bool Eliminar(int id);
    }
}