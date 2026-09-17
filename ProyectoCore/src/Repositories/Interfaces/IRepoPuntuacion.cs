using System;
using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepoPuntuacion
    {
        List<Puntuacion> ObtenerTodos();
        List<Puntuacion?> ObtenerPorFecha(byte fecha);
        List<Puntuacion?> ObtenerPorJugador(ushort id);
        Puntuacion? ObtenerPorFechaJugador(byte fecha, ushort id);
        Puntuacion Agregar(Puntuacion puntuacion);
        bool Eliminar(int id);
    }
}