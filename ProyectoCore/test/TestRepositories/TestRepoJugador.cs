using System;
using Models;
using Repositories;
using Xunit;

namespace TestRepositories
{
	public class TestRepoJugador
	{
		[IntegrationFact]
		[Trait("Category", "Integration")]
		public void PuedeAgregarBuscarRelacionesYEliminarJugador()
		{
			DBConnection conexion = TestRepositorioSupport.CrearConexion();
			RepoEquipo repositorioEquipo = new RepoEquipo(conexion);
			RepoJugador repositorio = new RepoJugador(conexion);
			Equipo equipo = repositorioEquipo.Agregar(new Equipo { Nombre = "Equipo " + Guid.NewGuid().ToString("N") });
			Jugador jugador = new Jugador
			{
				Nombre = "Jugador",
				Apellido = "Test",
				FechaNacimiento = new DateTime(1995, 1, 1),
				IdEquipo = equipo.Id,
				IdPosicion = 1,
				Cotizacion = 100m
			};

			jugador = repositorio.Agregar(jugador);
			try
			{
				Assert.NotEqual(0, jugador.Id);
				Assert.NotNull(repositorio.ObtenerPorId(jugador.Id));
				Assert.Equal(equipo.Id, repositorio.ObtenerEquipoPorJugador(jugador.Id)!.Id);
				Assert.Equal((byte)1, repositorio.ObtenerPosicionPorJugador(jugador.Id)!.Id);
				Assert.Contains(repositorio.ObtenerTodos(), encontrado => encontrado.Id == jugador.Id);
			}
			finally
			{
				repositorio.Eliminar(jugador.Id);
				repositorioEquipo.Eliminar(equipo.Id);
			}

			Assert.Null(repositorio.ObtenerPorId(jugador.Id));
		}
	}
}
