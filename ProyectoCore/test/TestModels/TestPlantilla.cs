using System.Collections.Generic;
using Models;
using Xunit;

namespace TestModels
{
    public class TestPlantilla
    {
        [Fact]
        public void FormacionCompletaEsValida()
        {
            Plantilla plantilla = new Plantilla();
            plantilla.PresupuestoMaximo = 1100m;

            plantilla.AgregarTitular(CrearJugador(1, Posicion.Arquero, 100m));
            plantilla.AgregarTitular(CrearJugador(2, Posicion.Defensor, 100m));
            plantilla.AgregarTitular(CrearJugador(3, Posicion.Defensor, 100m));
            plantilla.AgregarTitular(CrearJugador(4, Posicion.Defensor, 100m));
            plantilla.AgregarTitular(CrearJugador(5, Posicion.Defensor, 100m));
            plantilla.AgregarTitular(CrearJugador(6, Posicion.Mediocampista, 100m));
            plantilla.AgregarTitular(CrearJugador(7, Posicion.Mediocampista, 100m));
            plantilla.AgregarTitular(CrearJugador(8, Posicion.Mediocampista, 100m));
            plantilla.AgregarTitular(CrearJugador(9, Posicion.Mediocampista, 100m));
            plantilla.AgregarTitular(CrearJugador(10, Posicion.Delantero, 100m));
            plantilla.AgregarTitular(CrearJugador(11, Posicion.Delantero, 100m));

            Assert.True(plantilla.FormacionTitularValida());
            Assert.True(plantilla.EsValida());
        }

        [Fact]
        public void PresupuestoIncluyeTitularesYSuplentes()
        {
            Plantilla plantilla = new Plantilla();
            plantilla.AgregarTitular(CrearJugador(1, Posicion.Arquero, 125.50m));
            plantilla.AgregarSuplente(CrearJugador(2, Posicion.Defensor, 80.25m));

            Assert.Equal(205.75m, plantilla.ObtenerPresupuesto());
        }

        [Fact]
        public void PresupuestoExcedidoInvalidaLaPlantilla()
        {
            Plantilla plantilla = new Plantilla();
            plantilla.PresupuestoMaximo = 100m;
            plantilla.AgregarTitular(CrearJugador(1, Posicion.Arquero, 100.01m));

            Assert.False(plantilla.PresupuestoValido());
        }

        [Fact]
        public void NoPermiteSuperarCantidadMaximaDeJugadores()
        {
            Plantilla plantilla = new Plantilla();
            plantilla.CantidadMaximaJugadores = 1;
            plantilla.AgregarTitular(CrearJugador(1, Posicion.Arquero, 1m));

            Assert.Throws<InvalidOperationException>(() =>
                plantilla.AgregarSuplente(CrearJugador(2, Posicion.Defensor, 1m)));
        }

        [Fact]
        public void PuntajeFechaSumaSoloTitularesYOmiteLosQueNoJugaron()
        {
            Plantilla plantilla = new Plantilla();
            plantilla.AgregarTitular(CrearJugador(1, Posicion.Arquero, 1m));
            plantilla.AgregarSuplente(CrearJugador(2, Posicion.Defensor, 1m));

            List<Puntuacion> puntuaciones = new List<Puntuacion>
            {
                new Puntuacion { Fecha = 4, IdJugador = 1, Puntaje = 8.5m },
                new Puntuacion { Fecha = 4, IdJugador = 2, Puntaje = 10m }
            };

            Assert.Equal(8.5m, plantilla.PuntajeFecha(4, puntuaciones));
        }

        [Fact]
        public void NoPermiteRepetirJugador()
        {
            Plantilla plantilla = new Plantilla();
            plantilla.AgregarTitular(CrearJugador(1, Posicion.Arquero, 1m));

            Assert.Throws<InvalidOperationException>(() =>
                plantilla.AgregarSuplente(CrearJugador(1, Posicion.Defensor, 1m)));
        }

        private static Jugador CrearJugador(ushort id, byte posicion, decimal cotizacion)
        {
            return new Jugador
            {
                Id = id,
                Nombre = "Nombre",
                Apellido = "Apellido",
                FechaNacimiento = new System.DateTime(2000, 1, 1),
                IdEquipo = 1,
                IdPosicion = posicion,
                Cotizacion = cotizacion
            };
        }
    }
}