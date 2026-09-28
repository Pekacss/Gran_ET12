using System;
using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepoPosicion
    {
        List<Posicion> ObtenerTodos();
        Posicion? ObtenerPorId(byte id);
        List<Jugador> ObtenerJugadoresPorPosicion(byte id);
        Posicion Agregar(Posicion posicion);
        bool Eliminar(byte id);
    }
}