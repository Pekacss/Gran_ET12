using System;
using System.Data;
using Repositories;
using Xunit;

namespace TestRepositories
{
    public class TestDBConnection
    {
        [Fact]
        [Trait("Category", "Integration")]
        public void PuedeAbrirConexionMySql()
        {
            // Requiere MySQL activo y GRAN_ET12_CONNECTION_STRING configurada.
            string cadenaConexion = Environment.GetEnvironmentVariable("GRAN_ET12_CONNECTION_STRING") ?? string.Empty;
            DBConnection conexionDb = new DBConnection(cadenaConexion);

            using var conexion = conexionDb.CrearConexion();
            conexion.Open();

            Assert.Equal(ConnectionState.Open, conexion.State);
        }
    }
}