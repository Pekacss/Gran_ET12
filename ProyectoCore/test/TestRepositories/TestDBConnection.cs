using System.Data;
using Repositories;
using Xunit;

namespace TestRepositories
{
    public class TestDBConnection : TestRepoBase
    {
        [Fact]
        public void PuedeAbrirConexionMySql()
        {
            using var conexion = _conexion.CrearConexion();
            conexion.Open();

            Assert.Equal(ConnectionState.Open, conexion.State);
        }
    }
}