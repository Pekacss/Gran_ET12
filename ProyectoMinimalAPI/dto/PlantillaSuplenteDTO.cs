using System;
using Models;
namespace dto
{
    public class PlantillaSuplenteDTO
    {
        public int IdPlantilla { get; set; }
        public ushort IdJugador { get; set; }
        
        public PlantillaSuplenteDTO(PlantillaSuplente plantillaSuplente)
        {
            IdPlantilla = plantillaSuplente.IdPlantilla;
            IdJugador = plantillaSuplente.IdJugador;
        }
    }
}