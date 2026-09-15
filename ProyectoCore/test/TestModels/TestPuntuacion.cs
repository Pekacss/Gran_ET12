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
        public void OKGuardarPuntaje()
        {
            Puntuacion puntuacion = new Puntuacion();
            puntuacion.Puntaje = 8.5f;

            Assert.Equal(8.5f, puntuacion.Puntaje);
        }
    }
}