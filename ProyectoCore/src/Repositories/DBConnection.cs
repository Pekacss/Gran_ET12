using MySqlConnector;

namespace Repositories
{
    public class DBConnection
    {
        private readonly string _connectionString;

        public DBConnection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("La cadena de conexión no puede estar vacía.", nameof(connectionString));

            _connectionString = connectionString;
        }

        public MySqlConnection CrearConexion()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}