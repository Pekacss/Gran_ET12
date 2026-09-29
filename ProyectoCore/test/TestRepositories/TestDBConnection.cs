using System.Data;
using Repositories;
using Xunit;

namespace TestRepositories
{
    public class TestDBConnection
    {
        [Fact]
        [Trait("Category", "Integration")] // Requiere la base de datos activa.
        public void PuedeAbrirConexionMySql()
        {
            // Requiere MySQL activo en localhost.
            DBConnection conexionDb = TestRepositorioSupport.CrearConexion();

            using var conexion = conexionDb.CrearConexion();
            conexion.Open();

            Assert.Equal(ConnectionState.Open, conexion.State);
        }
    }
}