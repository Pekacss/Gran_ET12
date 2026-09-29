using Models;
using Xunit;

namespace TestModels
{
    public class TestPosicion
    {
        [Fact]
        public void PosicionConIdYNombreValidosEsValida()
        {
            Posicion posicion = new Posicion { Id = Posicion.Delantero, Nombre = "Delantero" };

            Assert.True(posicion.EsValida());
            posicion.Validar();
        }

        [Fact]
        public void IdFueraDeRangoHaceInvalidaLaPosicion()
        {
            Posicion posicion = new Posicion { Id = 5, Nombre = "Delantero" };

            Assert.False(posicion.EsValida());
            Assert.Throws<ArgumentException>(() => posicion.Validar());
        }

        [Fact]
        public void NombreVacioHaceInvalidaLaPosicion()
        {
            Posicion posicion = new Posicion { Id = Posicion.Arquero, Nombre = string.Empty };

            Assert.False(posicion.EsValida());
            Assert.Throws<ArgumentException>(() => posicion.Validar());
        }
    }
}