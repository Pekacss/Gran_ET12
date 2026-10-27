using System;
using Models;
namespace dto
{
    public class PosicionDTO
    {
        public string Nombre { get; set; } = string.Empty;

        public PosicionDTO(Posicion posicion)
        {
            Nombre = posicion.Nombre;
        }
    }
}
