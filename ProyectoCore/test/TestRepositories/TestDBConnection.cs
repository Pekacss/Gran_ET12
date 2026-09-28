using System;
using Dapper;
using Repositories;
using Xunit;

namespace TestRepositories
{
    public class TestDBConnection
    {
        [IntegrationFact]
        [Trait("Category", "Integration")]
        public void PuedeAbrirConexionMySqlYEjecutarSelect1()
        {
            string connectionString = Environment.GetEnvironmentVariable("GRAN_ET12_CONNECTION_STRING")!;

            using var connection = new DBConnection(connectionString).CrearConexion();
            connection.Open();

            int resultado = connection.ExecuteScalar<int>("SELECT 1");

            Assert.Equal(1, resultado);
        }
    }

    public sealed class IntegrationFactAttribute : FactAttribute
    {
        public IntegrationFactAttribute()
        {
            if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("GRAN_ET12_CONNECTION_STRING")))
                Skip = "Configure GRAN_ET12_CONNECTION_STRING y arranque MySQL para ejecutar la integración.";
        }
    }

    internal static class TestRepositorioSupport
    {
        public static DBConnection CrearConexion()
        {
            string connectionString = Environment.GetEnvironmentVariable("GRAN_ET12_CONNECTION_STRING")!;
            return new DBConnection(connectionString);
        }
    }
}