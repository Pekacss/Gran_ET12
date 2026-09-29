using Models;
using Repositories;
using Xunit;

namespace TestRepositories
{
	public class TestRepoPlantilla
	{
		[Fact]
		[Trait("Category", "Integration")]
		public void PuedeAgregarConsultarYEliminarPlantilla()
		{
			RepoPlantilla repositorio = new RepoPlantilla(TestRepositorioSupport.CrearConexion());
			Plantilla plantilla = repositorio.Agregar(new Plantilla
			{
				IdUsuario = 1,
				Fecha = 49,
				Nombre = "Plantilla " + System.Guid.NewGuid().ToString("N")
			});

			try
			{
				Assert.NotEqual(0, plantilla.Id);
				Assert.NotNull(repositorio.ObtenerPorId(plantilla.Id));
				Assert.Equal(plantilla.Id, repositorio.ObtenerPorIdUsuario(1)!.Id);
				Assert.Equal(plantilla.Id, repositorio.ObtenerPorFecha(49)!.Id);
				Assert.Equal(plantilla.Id, repositorio.ObtenerPorNombre(plantilla.Nombre!)!.Id);
				Assert.Empty(repositorio.ObtenerJugadoresPorPlantilla(plantilla.Id));
				Assert.Equal(0m, repositorio.ObtenerCalificacionPlantilla(plantilla.Id));
				Assert.Contains(repositorio.ObtenerTodos(), encontrada => encontrada.Id == plantilla.Id);
			}
			finally
			{
				repositorio.Eliminar(plantilla.Id);
			}
		}
	}
}
