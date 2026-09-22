namespace Models
{
    public class Puntuacion
    {
        public byte Fecha { get; set; }
        public ushort IdJugador { get; set; }
        public decimal Puntaje { get; set; }

        public bool EsValida()
        {
            return Fecha < 50 && Fecha != 0 && IdJugador != 0 && Puntaje >= 1m && Puntaje <= 10m;
        }

        public void Validar()
        {
            if (Fecha == 0 || Fecha >= 50)
            {
                throw new ArgumentOutOfRangeException(nameof(Fecha), "La fecha debe ser un entero menor a 50 y mayor a 0.");
            }
            if (IdJugador == 0)
            {
                throw new ArgumentException("La puntuación debe identificar a un jugador.");
            }
            if (Puntaje < 1m || Puntaje > 10m)
            {
                throw new ArgumentOutOfRangeException(nameof(Puntaje), "El puntaje debe estar entre 1 y 10.");
            }
        }
    }
}