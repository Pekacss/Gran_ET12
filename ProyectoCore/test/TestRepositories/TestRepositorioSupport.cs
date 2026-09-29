using Repositories;

namespace TestRepositories
{
    internal static class TestRepositorioSupport
    {
        private const string CadenaConexion = "Server=localhost;Port=3306;Database=bd_GranET12;User ID=root;Password=;";

        public static DBConnection CrearConexion()
        {
            return new DBConnection(CadenaConexion);
        }
    }
}