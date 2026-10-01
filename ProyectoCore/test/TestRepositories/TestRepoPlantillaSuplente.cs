using Models;
using Repositories;
using Xunit;

namespace TestRepositories
{
	public class TestRepoPlantillaSuplente : TestRepoBase
	{
		[Fact]
		public void PuedeAgregarBuscarJugadoresYEliminarSuplente()
		{
			RepoPlantilla repoPlantilla = new RepoPlantilla(_conexion);
			RepoPlantillaSuplente repositorio = new RepoPlantillaSuplente(_conexion);
			Plantilla plantilla = repoPlantilla.Agregar(new Plantilla { IdUsuario = 1, Fecha = 47, Nombre = "Suplente test" });

			try
			{
				PlantillaSuplente relacion = repositorio.Agregar(new PlantillaSuplente
				{
					IdPlantilla = plantilla.Id,
					IdJugador = 12
				});

				Assert.NotEqual(0, relacion.Id);
				Assert.NotNull(repositorio.ObtenerPorId(relacion.Id));
				Assert.Contains(repositorio.ObtenerTodos(), encontrada => encontrada.Id == relacion.Id);
				Assert.Contains(repositorio.ObtenerSuplentesPlantilla(plantilla.Id), jugador => jugador.Id == 12);
				Assert.True(repositorio.Eliminar(relacion.Id));
			}
			finally
			{
				repoPlantilla.Eliminar(plantilla.Id);
			}
		}
	}
}
