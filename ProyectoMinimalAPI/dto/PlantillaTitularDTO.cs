using System;
using Models;
namespace dto
{
    public class PlantillaTitularDTO
    {
        public int IdPlantilla { get; set; }
        public ushort IdJugador { get; set; }
        
        public PlantillaTitularDTO() { }

        public PlantillaTitular AModelo()
        {
            return new PlantillaTitular { IdPlantilla = IdPlantilla, IdJugador = IdJugador };
        }

        public PlantillaTitularDTO(PlantillaTitular plantillaTitular)
        {
            IdPlantilla = plantillaTitular.IdPlantilla;
            IdJugador = plantillaTitular.IdJugador;
        }
    }
}