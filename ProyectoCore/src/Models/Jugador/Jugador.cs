using System;

namespace Models
{
    public class Jugador
    {
        public ushort Id {get; set;}
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public string Apodo {get; set;} = string.Empty;
        public DateTime FechaNacimiento {get; set;} = DateTime.MinValue;
        public byte IdEquipo {get; set;}
        public float Cotizacion {get; set;}
        public byte IdPosicion {get; set;}
    }
}