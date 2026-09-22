namespace Models
{
    public class Posicion
    {
        public const byte Arquero = 1;
        public const byte Defensor = 2;
        public const byte Mediocampista = 3;
        public const byte Delantero = 4;

        public byte Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public bool EsValida()
        {
            return Id >= Arquero && Id <= Delantero && !string.IsNullOrWhiteSpace(Nombre);
        }

        public void Validar()
        {
            if (!EsValida())
            {
                throw new ArgumentException("La posición debe ser Arquero, Defensor, Mediocampista o Delantero.");
            }
        }
    }
}