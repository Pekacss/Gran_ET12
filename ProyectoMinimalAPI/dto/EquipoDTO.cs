using System;
using Models;
namespace dto
{
    public class EquipoDTO
    {
        public string Nombre { get; set; } = string.Empty;

        public EquipoDTO() { }

        public Equipo AModelo()
        {
            return new Equipo { Nombre = Nombre };
        }

        public EquipoDTO(Equipo equipo)
        {
            Nombre = equipo.Nombre;
        }
    }
}