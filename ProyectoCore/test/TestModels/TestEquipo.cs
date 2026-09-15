using Models;
using Xunit;

namespace TestModels
{
    public class TestEquipo
    {
        // En la capa de Model se testean las propiedades y comportamientos de las clases
        [Fact]
        public void TestGuardarId()
        {
            Equipo equipo = new Equipo();
            equipo.Id = 10;

            Assert.Equal(10, equipo.Id);
        }

        [Fact]
        public void TestGuardarNombre()
        {
            Equipo equipo = new Equipo();
            equipo.Nombre = "Riber";

            Assert.Equal("Riber", equipo.Nombre);
        }
    }
}