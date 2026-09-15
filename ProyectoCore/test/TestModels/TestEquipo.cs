using Models;
using Xunit;

namespace TestModels
{
    public class TestEquipo
    {
        // En la capa de Model se testean las propiedades y comportamientos de las clases
        [Fact]
        public void TestEquipoNull()
        {
            var equipo = new Equipo();
            Assert.NotNull(equipo);
        }
    }
}