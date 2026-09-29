using Models;
using Xunit;

namespace TestModels
{
    public class TestJugador
    {
        [Fact]
        public void CotizacionMaximaEsValida()
        {
            Jugador jugador = new Jugador();
            jugador.Nombre = "Lionel";
            jugador.Apellido = "Messi";
            jugador.FechaNacimiento = new DateTime(1987, 6, 24);
            jugador.IdEquipo = 1;
            jugador.IdPosicion = Posicion.Delantero;
            jugador.Cotizacion = Jugador.CotizacionMaxima;

            Assert.True(jugador.EsValido());
            jugador.Validar();
        }

        [Fact]
        public void CotizacionSuperiorAlMaximoEsInvalida()
        {
            Jugador jugador = new Jugador();
            jugador.Nombre = "Lionel";
            jugador.Apellido = "Messi";
            jugador.FechaNacimiento = new DateTime(1987, 6, 24);
            jugador.IdEquipo = 1;
            jugador.IdPosicion = Posicion.Delantero;
            jugador.Cotizacion = Jugador.CotizacionMaxima + 0.01m;

            Assert.False(jugador.EsValido());
            Assert.Throws<ArgumentOutOfRangeException>(() => jugador.Validar());
        }

        [Fact]
        public void DatosObligatoriosAusentesHacenInvalidoAlJugador()
        {
            Jugador jugador = new Jugador();

            Assert.False(jugador.EsValido());
            Assert.Throws<ArgumentException>(() => jugador.Validar());
        }

        [Fact]
        public void FechaDeNacimientoAusenteNoEsValida()
        {
            Jugador jugador = new Jugador
            {
                Nombre = "Lionel",
                Apellido = "Messi",
                IdEquipo = 1,
                IdPosicion = Posicion.Delantero,
                Cotizacion = 100m
            };

            Assert.False(jugador.EsValido());
            Assert.Throws<ArgumentException>(() => jugador.Validar());
        }

        [Fact]
        public void EquipoOCategoriaDePosicionInvalidosNoPasanValidacion()
        {
            Jugador jugador = new Jugador
            {
                Nombre = "Lionel",
                Apellido = "Messi",
                FechaNacimiento = new DateTime(1987, 6, 24),
                IdPosicion = Posicion.Delantero,
                Cotizacion = 100m
            };

            Assert.False(jugador.EsValido());
            Assert.Throws<ArgumentException>(() => jugador.Validar());

            jugador.IdEquipo = 1;
            jugador.IdPosicion = 5;

            Assert.False(jugador.EsValido());
            Assert.Throws<ArgumentException>(() => jugador.Validar());
        }
    }
}