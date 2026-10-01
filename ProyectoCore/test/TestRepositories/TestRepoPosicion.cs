using Repositories;
using Xunit;

namespace TestRepositories
{
	public class TestRepoPosicion : TestRepoBase
	{
		[Fact]
		public void PuedeObtenerPosicionesYSusJugadores()
		{
			RepoPosicion repositorio = new RepoPosicion(_conexion);

			Assert.Equal("Arquero", repositorio.ObtenerPorId(1)!.Nombre);
			Assert.Contains(repositorio.ObtenerTodos(), posicion => posicion.Id == 1);
			Assert.Contains(repositorio.ObtenerJugadoresPorPosicion(1), jugador => jugador.Id == 1);
			Assert.False(repositorio.Eliminar(99));
		}
	}
}
