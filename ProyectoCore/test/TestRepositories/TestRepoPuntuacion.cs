using Models;
using Repositories;
using Xunit;

namespace TestRepositories
{
	public class TestRepoPuntuacion
	{
		[IntegrationFact]
		[Trait("Category", "Integration")]
		public void PuedeConsultarAgregarYEliminarPorClaveCompuesta()
		{
			RepoPuntuacion repositorio = new RepoPuntuacion(TestRepositorioSupport.CrearConexion());
			Puntuacion puntuacion = new Puntuacion { Fecha = 49, IdJugador = 1, Puntaje = 9.5m };
			repositorio.Agregar(puntuacion);

			Assert.Contains(repositorio.ObtenerTodos(), encontrada => encontrada.Fecha == 49 && encontrada.IdJugador == 1);
			Assert.Contains(repositorio.ObtenerPorFecha(49), encontrada => encontrada.IdJugador == 1);
			Assert.Contains(repositorio.ObtenerPorJugador(1), encontrada => encontrada.Fecha == 49);
			Assert.Equal(9.5m, repositorio.ObtenerPorFechaJugador(49, 1)!.Puntaje);
			Assert.True(repositorio.Eliminar(49, 1));
			Assert.Null(repositorio.ObtenerPorFechaJugador(49, 1));
		}
	}
}
