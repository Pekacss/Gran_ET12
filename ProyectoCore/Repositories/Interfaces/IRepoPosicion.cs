using System;
using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepoPosicion
    {
        List<Posicion> ObtenerTodos();
        Posicion? ObtenerPorId(ushort id);
        List<Jugador> ObtenerJugadoresPorPosicion(ushort id);
        Posicion Agregar(Posicion posicion);
        bool Eliminar(byte id);
    }
}