namespace Models
{
    public class Equipo
    {
        public byte Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public bool EsValido()
        {
            return !string.IsNullOrWhiteSpace(Nombre);
        }

        public void Validar()
        {
            if (!EsValido())
            {
                throw new ArgumentException("El equipo debe tener un nombre.");
            }
        }
    }
}