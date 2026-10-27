using System;
using Models;
namespace dto
{
    public class PlantillaDTO
    {
        public ushort IdUsuario { get; set; }
        public byte Fecha { get; set; }
        public string? Nombre { get; set; }

        public PlantillaDTO(Plantilla plantilla)
        {
            IdUsuario = plantilla.IdUsuario;
            Fecha = plantilla.Fecha;
            Nombre = plantilla.Nombre;
        }
    }
}