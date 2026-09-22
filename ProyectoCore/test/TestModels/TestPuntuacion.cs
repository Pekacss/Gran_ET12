using Models;
using Xunit;

namespace TestModels
{
    public class TestPuntuacion
    {
        [Fact]
        public void OKGuardarFecha()
        {
            Puntuacion puntuacion = new Puntuacion();
            puntuacion.Fecha = 4;

            Assert.Equal(4, puntuacion.Fecha);
        }

        [Fact]
        public void OKGuardarIdJugador()
        {
            Puntuacion puntuacion = new Puntuacion();
            puntuacion.IdJugador = 18;

            Assert.Equal(18, puntuacion.IdJugador);
        }

        [Fact]
        public void PuntajeEntreUnoYDiezEsValido()
        {
            Puntuacion puntuacion = new Puntuacion();
            puntuacion.Fecha = 4;
            puntuacion.IdJugador = 18;
            puntuacion.Puntaje = 8.5m;

            Assert.True(puntuacion.EsValida());
        }

        [Theory]
        [InlineData(0.9)]
        [InlineData(10.1)]
        public void PuntajeFueraDeRangoEsInvalido(decimal puntaje)
        {
            Puntuacion puntuacion = new Puntuacion();
            puntuacion.Fecha = 4;
            puntuacion.IdJugador = 18;
            puntuacion.Puntaje = puntaje;

            Assert.False(puntuacion.EsValida());
            Assert.Throws<ArgumentOutOfRangeException>(() => puntuacion.Validar());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(50)]
        public void FechaFueraDeRangoEsInvalida(byte fecha)
        {
            Puntuacion puntuacion = new Puntuacion();
            puntuacion.Fecha = fecha;
            puntuacion.IdJugador = 18;
            puntuacion.Puntaje = 8m;

            Assert.False(puntuacion.EsValida());
        }
    }
}