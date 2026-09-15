using Models;
using Xunit;

namespace TestModels
{
    public class TestPlantilla
    {
        [Fact]
        public void TestOKGuardarId()
        {
            Plantilla plantilla = new Plantilla();
            plantilla.Id = 67;

            Assert.Equal(67, plantilla.Id);
        }

        [Fact]
        public void TestOKGuardarIdUsuario()
        {
            Plantilla plantilla = new Plantilla();
            plantilla.IdUsuario = 8;

            Assert.Equal(8, plantilla.IdUsuario);
        }

        [Fact]
        public void TestOKGuardarFecha()
        {
            Plantilla plantilla = new Plantilla();
            plantilla.Fecha = 10;

            Assert.Equal(10, plantilla.Fecha);
        }

        [Fact]
        public void TestOKNombreNulo()
        {
            Plantilla plantilla = new Plantilla();

            plantilla.Nombre = null;

            Assert.Null(plantilla.Nombre);
        }
    }
}