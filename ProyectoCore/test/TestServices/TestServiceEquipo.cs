using Interfaces;
using Models;
using Services;

namespace TestServices
{
	public class TestServiceEquipo
	{
		[Fact]
		public void AgregarEquipoSinNombreLanzaArgumentExceptionAntesDeUsarRepositorio()
		{
			ServiceEquipo servicio = new ServiceEquipo(new RepositorioEquipoFalso());

			Assert.Throws<ArgumentException>(() => servicio.Agregar(new Equipo()));
		}

		private class RepositorioEquipoFalso : IRepoEquipo
		{
			public Equipo Agregar(Equipo equipo)
			{
				throw new InvalidOperationException("El repositorio no debería ejecutarse.");
			}

			public bool Eliminar(byte id)
			{
				throw new NotImplementedException();
			}

			public List<Equipo> ObtenerTodos()
			{
				throw new NotImplementedException();
			}

			public Equipo? ObtenerPorId(byte id)
			{
				throw new NotImplementedException();
			}

			public List<Jugador> ObtenerJugadoresPorEquipo(byte id)
			{
				throw new NotImplementedException();
			}
		}
	}
}
