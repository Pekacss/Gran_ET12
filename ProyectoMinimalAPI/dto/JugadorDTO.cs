using System;
using Models;
namespace dto
{
    public class JugadorDTO
    {
        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;
        public string Apodo { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; } = DateOnly.MinValue;
        public byte IdEquipo { get; set; }
        public decimal Cotizacion { get; set; }
        public byte IdPosicion { get; set; }
        
        public JugadorDTO(Jugador jugador)
        {
            Nombre = jugador.Nombre;
            Apellido = jugador.Apellido;
            Apodo = jugador.Apodo;
            FechaNacimiento = DateOnly.FromDateTime(jugador.FechaNacimiento);
            IdEquipo = jugador.IdEquipo;
            Cotizacion = jugador.Cotizacion;
            IdPosicion = jugador.IdPosicion;
        }
    }
}