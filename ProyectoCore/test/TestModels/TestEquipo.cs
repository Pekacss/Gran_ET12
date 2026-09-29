using Models;
using Xunit;

namespace TestModels
{
    public class TestEquipo
    {
        [Fact]
        public void EquipoConNombreEsValido()
        {
            Equipo equipo = new Equipo { Nombre = "River Plate" };

            Assert.True(equipo.EsValido());
            equipo.Validar();
        }

        [Fact]
        public void EquipoSinNombreNoEsValido()
        {
            Equipo equipo = new Equipo { Nombre = " " };

            Assert.False(equipo.EsValido());
            Assert.Throws<ArgumentException>(() => equipo.Validar());
        }
    }
}