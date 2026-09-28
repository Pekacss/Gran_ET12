using Models;
using Repositories;
using Xunit;

namespace TestRepositories
{
	public class TestRepoPlantillaTitular
	{
		[IntegrationFact]
		[Trait("Category", "Integration")]
		public void PuedeAgregarBuscarJugadoresYEliminarTitular()
		{
			DBConnection conexion = TestRepositorioSupport.CrearConexion();
			RepoPlantilla repoPlantilla = new RepoPlantilla(conexion);
			RepoPlantillaTitular repositorio = new RepoPlantillaTitular(conexion);
			Plantilla plantilla = repoPlantilla.Agregar(new Plantilla { IdUsuario = 1, Fecha = 48, Nombre = "Titular test" });

			try
			{
				PlantillaTitular relacion = repositorio.Agregar(new PlantillaTitular
				{
					IdPlantilla = plantilla.Id,
					IdJugador = 12
				});

				Assert.NotEqual(0, relacion.Id);
				Assert.NotNull(repositorio.ObtenerPorId(relacion.Id));
				Assert.Contains(repositorio.ObtenerTodos(), encontrada => encontrada.Id == relacion.Id);
				Assert.Contains(repositorio.ObtenerTitularesPlantilla(plantilla.Id), jugador => jugador.Id == 12);
				Assert.True(repositorio.Eliminar(relacion.Id));
			}
			finally
			{
				repoPlantilla.Eliminar(plantilla.Id);
			}
		}
	}
}
