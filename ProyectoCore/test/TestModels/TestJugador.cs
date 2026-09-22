using Models;
using Xunit;

namespace TestModels
{
    public class TestJugador
    {
        [Fact]
        public void TestGuardarId()
        {
            Jugador jugador = new Jugador();
            jugador.Id = 25;

            Assert.Equal(25, jugador.Id);
        }

        [Fact]
        public void TestGuardarNombreYApellido()
        {
            Jugador jugador = new Jugador();
            jugador.Nombre = "Paredes";
            jugador.Apellido = "Messi";

            Assert.Equal("Paredes", jugador.Nombre);
            Assert.Equal("Messi", jugador.Apellido);
        }

        [Fact]
        public void TestGuardarApodo()
        {
            Jugador jugador = new Jugador();

            Assert.Equal(string.Empty, jugador.Apodo);

            jugador.Apodo = "El Heredero";

            Assert.Equal("El Heredero", jugador.Apodo);
        }

        [Fact]
        public void TestGuardarFechaNacimiento()
        {
            Jugador jugador = new Jugador();
            DateTime fecha = new DateTime(1987, 6, 24);

            jugador.FechaNacimiento = fecha;

            Assert.Equal(fecha, jugador.FechaNacimiento);
        }

        [Fact]
        public void TestGuardarDatosRelacionados()
        {
            Jugador jugador = new Jugador();

            jugador.IdEquipo = 5;
            jugador.IdPosicion = 2;

            Assert.Equal(5, jugador.IdEquipo);
            Assert.Equal(2, jugador.IdPosicion);
        }

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
    }
}