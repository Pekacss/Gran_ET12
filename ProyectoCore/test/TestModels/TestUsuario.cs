using Models;
using Xunit;

namespace TestModels
{
    public class TestUsuario
    {
        [Fact]
        public void ContraseñaDe64CaracteresEsValida()
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = "Thiago";
            usuario.Apellido = "Rojas";
            usuario.Email = "thiago@email.com";
            usuario.FechaNacimiento = new DateTime(2008, 5, 10);
            usuario.Contraseña = new string('a', 64);

            Assert.True(usuario.EsValido());
            usuario.Validar();
        }

        [Fact]
        public void ContraseñaConLongitudIncorrectaEsInvalida()
        {
            Usuario usuario = new Usuario();
            usuario.Contraseña = "123456";

            Assert.False(usuario.EsValido());
            Assert.Throws<ArgumentException>(() => usuario.Validar());
        }

        [Fact]
        public void UsuarioSinDatosObligatoriosNoEsValido()
        {
            Usuario usuario = new Usuario();

            Assert.False(usuario.EsValido());
            Assert.Throws<ArgumentException>(() => usuario.Validar());
        }

        [Fact]
        public void UsuarioComunNoEsAdministrador()
        {
            Usuario usuario = new Usuario();

            Assert.False(usuario.EsAdministrador());
            Assert.Throws<ArgumentException>(() => usuario.ValidarAdministrador());
        }

        [Fact]
        public void AdministradorEsReconocidoComoTal()
        {
            Usuario usuario = new Usuario { Administrador = true };

            Assert.True(usuario.EsAdministrador());
            usuario.ValidarAdministrador();
        }
    }
}