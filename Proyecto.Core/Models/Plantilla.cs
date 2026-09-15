using System;
namespace Models
{
    public class Plantilla
    {
        public int Id { get; set; }
        public ushort IdUsuario { get; set; }
        public byte Fecha { get; set; }
        public string? Nombre { get; set; }
    }
}