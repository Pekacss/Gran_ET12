using System;
namespace Models
{
    public class Puntuacion
    {
        public byte Fecha { get; set; }
        public ushort IdJugador { get; set; }
        public float Puntaje { get; set; }
    }
}