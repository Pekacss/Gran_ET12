using System;
using Repositories;

namespace TestRepositories
{
    internal static class TestRepositorioSupport
    {
        public static DBConnection CrearConexion()
        {
            string connectionString = Environment.GetEnvironmentVariable("GRAN_ET12_CONNECTION_STRING") ?? string.Empty;
            return new DBConnection(connectionString);
        }
    }
}