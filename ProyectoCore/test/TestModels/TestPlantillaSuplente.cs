using Models;
using Xunit;

namespace TestModels
{
    public class TestPlantillaSuplente
    {
        [Fact]
        public void TestOKGuardarId()
        {
            PlantillaSuplente suplente = new PlantillaSuplente();
            suplente.Id = 20;

            Assert.Equal(20, suplente.Id);
        }

        [Fact]
        public void TestOKGuardarIdPlantilla()
        {
            PlantillaSuplente suplente = new PlantillaSuplente();
            suplente.IdPlantilla = 7;

            Assert.Equal(7, suplente.IdPlantilla);
        }

        [Fact]
        public void TestOKGuardarIdJugador()
        {
            PlantillaSuplente suplente = new PlantillaSuplente();
            suplente.IdJugador = 35;

            Assert.Equal(35, suplente.IdJugador);
        }
    }
}