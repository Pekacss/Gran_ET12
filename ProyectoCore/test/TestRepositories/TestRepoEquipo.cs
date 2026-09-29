using System;
using Models;
using Repositories;
using Xunit;

namespace TestRepositories
{
	public class TestRepoEquipo
	{
		[Fact]
		[Trait("Category", "Integration")]
		public void PuedeAgregarBuscarConsultarJugadoresYEliminarEquipo()
		{
			RepoEquipo repositorio = new RepoEquipo(TestRepositorioSupport.CrearConexion());
			Equipo equipo = repositorio.Agregar(new Equipo { Nombre = "Repo " + Guid.NewGuid().ToString("N") });

			Assert.NotEqual(0, equipo.Id);
			Assert.Equal(equipo.Nombre, repositorio.ObtenerPorId(equipo.Id)!.Nombre);
			Assert.Contains(repositorio.ObtenerTodos(), encontrado => encontrado.Id == equipo.Id);
			Assert.Empty(repositorio.ObtenerJugadoresPorEquipo(equipo.Id));
			Assert.True(repositorio.Eliminar(equipo.Id));
			Assert.Null(repositorio.ObtenerPorId(equipo.Id));
		}
	}
}
