using System;
using System.Collections.Generic;
using Interfaces;
using Models;
using Services;
using Xunit;

namespace TestServices
{
	public class TestServiceUsuario
	{
		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public void AgregarGuardaHashDe64CaracteresYLoginConservaAdministrador(bool administrador)
		{
			MockeoUsuario mock = new MockeoUsuario();
			ServiceUsuario servicio = new ServiceUsuario(mock);
			Usuario usuario = CrearUsuario(administrador);

			servicio.Agregar(usuario);

			Assert.NotEqual("clave-prueba", mock.UsuarioGuardado!.Contraseña);
			Assert.Equal(64, mock.UsuarioGuardado.Contraseña.Length);
			Assert.Equal(48, Convert.FromBase64String(mock.UsuarioGuardado.Contraseña).Length);
			Assert.True(mock.UsuarioGuardado.EsValido());

			Usuario? usuarioAutenticado = servicio.IniciarSesion(usuario.Email, "clave-prueba");

			Assert.NotNull(usuarioAutenticado);
			Assert.Equal(administrador, usuarioAutenticado!.Administrador);
		}

		[Fact]
		public void LoginRechazaUnaContraseñaIncorrecta()
		{
			MockeoUsuario repositorio = new MockeoUsuario();
			ServiceUsuario servicio = new ServiceUsuario(repositorio);
			Usuario usuario = CrearUsuario(false);
			servicio.Agregar(usuario);

			Usuario? usuarioAutenticado = servicio.IniciarSesion(usuario.Email, "otra-clave");

			Assert.Null(usuarioAutenticado);
		}

		[Fact]
		public void LoginRechazaUnEmailInexistente()
		{
			ServiceUsuario servicio = new ServiceUsuario(new MockeoUsuario());

			Assert.Null(servicio.IniciarSesion("inexistente@example.com", "clave-prueba"));
		}

		[Fact]
		public void LaMismaContraseñaGeneraHashesDistintosPorLaSalAleatoria()
		{
			MockeoUsuario repositorio = new MockeoUsuario();
			ServiceUsuario servicio = new ServiceUsuario(repositorio);
			Usuario primerUsuario = CrearUsuario(false);
			servicio.Agregar(primerUsuario);
			string primerHash = repositorio.UsuarioGuardado!.Contraseña;

			Usuario segundoUsuario = CrearUsuario(false);
			segundoUsuario.Email = "otro@example.com";
			servicio.Agregar(segundoUsuario);

			Assert.NotEqual(primerHash, repositorio.UsuarioGuardado!.Contraseña);
		}

		private static Usuario CrearUsuario(bool administrador)
		{
			return new Usuario
			{
				Nombre = "Thiago",
				Apellido = "Rojas",
				Email = "thiago@example.com",
				FechaNacimiento = new DateTime(2008, 5, 10),
				Administrador = administrador,
				Contraseña = "clave-prueba"
			};
		}

		private sealed class MockeoUsuario : IRepoUsuario
		{
			public Usuario? UsuarioGuardado { get; private set; }

			public Usuario Agregar(Usuario usuario)
			{
				usuario.Id = 1;
				UsuarioGuardado = usuario;
				return usuario;
			}

			public List<Usuario> ObtenerTodos()
			{
				if (UsuarioGuardado == null)
					return new List<Usuario>();

				return new List<Usuario> { UsuarioGuardado };
			}

			public Usuario? ObtenerPorId(ushort id)
			{
				if (UsuarioGuardado != null && UsuarioGuardado.Id == id)
					return UsuarioGuardado;

				return null;
			}

			public Usuario? ObtenerPorEmail(string email)
			{
				if (UsuarioGuardado != null && UsuarioGuardado.Email == email)
					return UsuarioGuardado;

				return null;
			}

			public bool Eliminar(ushort id)
			{
				if (UsuarioGuardado == null || UsuarioGuardado.Id != id)
					return false;

				UsuarioGuardado = null;
				return true;
			}
		}
	}
}
