using System;
using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepoPuntuacion
    {
        List<Puntuacion> ObtenerTodos();
        Puntuacion? ObtenerPorFecha(byte fecha);
        Puntuacion? ObtenerPorJugador(ushort id);
        Puntuacion? ObtenerPorFechaJugador(byte fecha, ushort id);
        Puntuacion Agregar(Puntuacion puntuacion);
        bool Eliminar(int id);
    }
}