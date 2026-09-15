using Models;
using Xunit;

namespace TestModels
{
    public class TestPlantillaTitular
    {
        [Fact]
        public void TestOKGuardarId()
        {
            PlantillaTitular titular = new PlantillaTitular();
            titular.Id = 20;

            Assert.Equal(20, titular.Id);
        }

        [Fact]
        public void TestOKGuardarIdPlantilla()
        {
            PlantillaTitular titular = new PlantillaTitular();
            titular.IdPlantilla = 7;

            Assert.Equal(7, titular.IdPlantilla);
        }

        [Fact]
        public void TestOKGuardarIdJugador()
        {
            PlantillaTitular titular = new PlantillaTitular();
            titular.IdJugador = 35;

            Assert.Equal(35, titular.IdJugador);
        }
    }
}