using System;
using Repositories;
using Models;
using Xunit;

namespace TestRepositories
{
	public class TestRepoUsuario : TestRepoBase
	{
		[Fact]
		public void PuedeAgregarBuscarPorIdEmailYEliminarUsuario()
		{
			RepoUsuario repositorio = new RepoUsuario(_conexion);
			Usuario usuario = new Usuario
			{
				Nombre = "Test",
				Apellido = "Repository",
				Email = "repo-" + Guid.NewGuid().ToString("N") + "@example.com",
				FechaNacimiento = new DateTime(1990, 1, 1),
				Contraseña = new string('a', 64)
			};

			usuario = repositorio.Agregar(usuario);
			try
			{
				Assert.NotEqual(0, usuario.Id);
				Assert.NotNull(repositorio.ObtenerPorId(usuario.Id));
				Assert.Equal(usuario.Id, repositorio.ObtenerPorEmail(usuario.Email)!.Id);
				Assert.Contains(repositorio.ObtenerTodos(), encontrado => encontrado.Id == usuario.Id);
			}
			finally
			{
				repositorio.Eliminar(usuario.Id);
			}
		}
	}
}
