using Models;
using Xunit;

namespace TestModels
{
    public class TestUsuario
    {
        [Fact]
        public void OKGuardarId()
        {
            Usuario usuario = new Usuario();
            usuario.Id = 10;

            Assert.Equal(10, usuario.Id);
        }

        [Fact]
        public void OKGuardarNombreYApellido()
        {
            Usuario usuario = new Usuario();

            usuario.Nombre = "Thiago";
            usuario.Apellido = "Rojas";

            Assert.Equal("Thiago", usuario.Nombre);
            Assert.Equal("Rojas", usuario.Apellido);
        }

        [Fact]
        public void OKGuardarEmail()
        {
            Usuario usuario = new Usuario();
            usuario.Email = "thiago@email.com";

            Assert.Equal("thiago@email.com", usuario.Email);
        }

        [Fact]
        public void OKGuardarFechaNacimiento()
        {
            Usuario usuario = new Usuario();
            DateTime fecha = new DateTime(2008, 5, 10);

            usuario.FechaNacimiento = fecha;

            Assert.Equal(fecha, usuario.FechaNacimiento);
        }

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
        }

        [Fact]
        public void ContraseñaConLongitudIncorrectaEsInvalida()
        {
            Usuario usuario = new Usuario();
            usuario.Contraseña = "123456";

            Assert.False(usuario.EsValido());
            Assert.Throws<ArgumentException>(() => usuario.Validar());
        }
    }
}