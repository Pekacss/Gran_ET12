using Models;
using Xunit;

namespace TestModels
{
    public class TestPuntuacion
    {
        [Fact]
        public void PuntajeEntreUnoYDiezEsValido()
        {
            Puntuacion puntuacion = new Puntuacion();
            puntuacion.Fecha = 4;
            puntuacion.IdJugador = 18;
            puntuacion.Puntaje = 8.5m;

            Assert.True(puntuacion.EsValida());
        }

        [Fact]
        public void PuntajeMenorAUnoEsInvalido()
        {
            Puntuacion puntuacion = new Puntuacion { Fecha = 4, IdJugador = 18, Puntaje = 0.9m };

            Assert.False(puntuacion.EsValida());
            Assert.Throws<ArgumentOutOfRangeException>(() => puntuacion.Validar());
        }

        [Fact]
        public void PuntajeMayorADiezEsInvalido()
        {
            Puntuacion puntuacion = new Puntuacion { Fecha = 4, IdJugador = 18, Puntaje = 10.1m };

            Assert.False(puntuacion.EsValida());
            Assert.Throws<ArgumentOutOfRangeException>(() => puntuacion.Validar());
        }

        [Fact]
        public void FechaCeroEsInvalida()
        {
            Puntuacion puntuacion = new Puntuacion { Fecha = 0, IdJugador = 18, Puntaje = 8m };

            Assert.False(puntuacion.EsValida());
            Assert.Throws<ArgumentOutOfRangeException>(() => puntuacion.Validar());
        }

        [Fact]
        public void FechaCincuentaEsInvalida()
        {
            Puntuacion puntuacion = new Puntuacion { Fecha = 50, IdJugador = 18, Puntaje = 8m };

            Assert.False(puntuacion.EsValida());
            Assert.Throws<ArgumentOutOfRangeException>(() => puntuacion.Validar());
        }

        [Fact]
        public void IdentificadorDeJugadorCeroEsInvalido()
        {
            Puntuacion puntuacion = new Puntuacion { Fecha = 4, IdJugador = 0, Puntaje = 8m };

            Assert.False(puntuacion.EsValida());
            Assert.Throws<ArgumentException>(() => puntuacion.Validar());
        }
    }
}