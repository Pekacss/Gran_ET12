namespace Models
{
    public class Jugador
    {
        public const decimal CotizacionMaxima = 99999999.99m;

        public ushort Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Apodo { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; } = DateTime.MinValue;
        public byte IdEquipo { get; set; }
        public decimal Cotizacion { get; set; }
        public byte IdPosicion { get; set; }

        public bool EsValido()
        {
            return !string.IsNullOrWhiteSpace(Nombre)
                && !string.IsNullOrWhiteSpace(Apellido)
                && FechaNacimiento != DateTime.MinValue
                && Cotizacion >= 0m
                && Cotizacion <= CotizacionMaxima
                && IdEquipo != 0
                && IdPosicion >= Posicion.Arquero
                && IdPosicion <= Posicion.Delantero;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellido))
            {
                throw new ArgumentException("El jugador debe tener nombre y apellido.");
            }
            if (FechaNacimiento == DateTime.MinValue)
            {
                throw new ArgumentException("El jugador debe tener fecha de nacimiento.");
            }
            if (Cotizacion < 0m || Cotizacion > CotizacionMaxima)
            {
                throw new ArgumentOutOfRangeException(nameof(Cotizacion), "La cotización debe estar entre 0 y 99.999.999,99.");
            }
            if (IdEquipo == 0 || IdPosicion < Posicion.Arquero || IdPosicion > Posicion.Delantero)
            {
                throw new ArgumentException("El jugador debe tener equipo y una posición válida.");
            }
        }
    }
}