using System;
using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepoEquipo
    {
        List<Equipo> ObtenerTodos();
        Equipo? ObtenerPorId(byte id);
        List<Jugador> ObtenerJugadoresPorEquipo(byte id);
        Equipo Agregar(Equipo equipo);
        bool Eliminar(byte id);
    }
}