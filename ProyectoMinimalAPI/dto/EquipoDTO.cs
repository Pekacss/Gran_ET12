using System;
using Models;
namespace dto
{
    public class EquipoDTO
    {
        public string Nombre { get; set; } = string.Empty;

        public EquipoDTO(Equipo equipo)
        {
            Nombre = equipo.Nombre;
        }
    }
}