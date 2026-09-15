using Models;
using Xunit;

namespace TestModels
{
    public class TestPosicion
    {
        [Fact]
        public void TestOKGuardarId()
        {
            Posicion posicion = new Posicion();
            posicion.Id = 3;

            Assert.Equal(3, posicion.Id);
        }

        [Fact]
        public void TestOKGuardarNombre()
        {
            Posicion posicion = new Posicion();
            posicion.Nombre = "Delantero";

            Assert.Equal("Delantero", posicion.Nombre);
        }
    }
}