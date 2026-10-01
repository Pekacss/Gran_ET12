using System;
using System.Collections.Generic;
using Interfaces;
using Models;
using Services;
using Xunit;

namespace TestServices
{
    public class TestServicePlantilla
    {
        [Fact]
        public void TestAgregarJugadorYaAnadido()
        {
            MockeoPlantilla mock = new MockeoPlantilla();
            ServicePlantilla service = new ServicePlantilla(mock);

            Plantilla plantilla = new Plantilla();
            Jugador jugador = CrearJugador(1, Posicion.Arquero, 100m);
            plantilla.AgregarTitular(jugador);

            // El jugador ya está en la plantilla, no debería poder agregarse de nuevo.
            Assert.Throws<InvalidOperationException>(() => plantilla.AgregarSuplente(jugador));

            service.Agregar(plantilla);
            Assert.Single(mock.Agregados);
        }

        [Fact]
        public void TestAgregarDelegaEnElRepositorio()
        {
            MockeoPlantilla repoFake = new MockeoPlantilla();
            ServicePlantilla service = new ServicePlantilla(repoFake);

            Plantilla plantilla = new Plantilla { IdUsuario = 1, Fecha = 1, Nombre = "Plantilla" };

            Plantilla resultado = service.Agregar(plantilla);

            Assert.Same(plantilla, resultado);
            Assert.Contains(plantilla, repoFake.Agregados);
        }

        [Fact]
        public void TestEliminarDelegaEnElRepositorio()
        {
            MockeoPlantilla repoFake = new MockeoPlantilla();
            ServicePlantilla service = new ServicePlantilla(repoFake);
            Plantilla plantilla = service.Agregar(new Plantilla { IdUsuario = 1, Fecha = 1, Nombre = "Plantilla" });

            bool eliminado = service.Eliminar(plantilla.Id);

            Assert.True(eliminado);
            Assert.Null(service.ObtenerPorId(plantilla.Id));
        }

        private static Jugador CrearJugador(ushort id, byte posicion, decimal cotizacion)
        {
            return new Jugador
            {
                Id = id,
                Nombre = "Nombre",
                Apellido = "Apellido",
                FechaNacimiento = new DateTime(2000, 1, 1),
                IdEquipo = 1,
                IdPosicion = posicion,
                Cotizacion = cotizacion
            };
        }

        private class MockeoPlantilla : IRepoPlantilla
        {
            private int _siguienteId = 1;

            public List<Plantilla> Agregados { get; } = new List<Plantilla>();

            public Plantilla Agregar(Plantilla plantilla)
            {
                plantilla.Id = _siguienteId++;
                Agregados.Add(plantilla);
                return plantilla;
            }

            public List<Plantilla> ObtenerTodos()
            {
                return Agregados;
            }

            public Plantilla? ObtenerPorIdUsuario(ushort id)
            {
                return Agregados.Find(p => p.IdUsuario == id);
            }

            public Plantilla? ObtenerPorFecha(byte fecha)
            {
                return Agregados.Find(p => p.Fecha == fecha);
            }

            public Plantilla? ObtenerPorNombre(string nombre)
            {
                return Agregados.Find(p => p.Nombre == nombre);
            }

            public Plantilla? ObtenerPorId(int id)
            {
                return Agregados.Find(p => p.Id == id);
            }

            public List<Jugador> ObtenerJugadoresPorPlantilla(int id)
            {
                Plantilla? plantilla = ObtenerPorId(id);
                return plantilla == null ? new List<Jugador>() : plantilla.Titulares;
            }

            public decimal ObtenerCalificacionPlantilla(int id)
            {
                return 0m;
            }

            public bool Eliminar(int id)
            {
                Plantilla? plantilla = ObtenerPorId(id);
                if (plantilla == null)
                    return false;

                return Agregados.Remove(plantilla);
            }
        }
    }
}