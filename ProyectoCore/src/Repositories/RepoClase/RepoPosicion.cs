using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoPosicion : IRepoPosicion
    {
        private readonly DBConnection _dbConnection;

        public RepoPosicion(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Posicion Agregar(Posicion posicion)
        {
            using var connection = _dbConnection.CrearConexion();
            connection.Execute("sp_Posicion_Agregar", new { p_Id = posicion.Id, p_Nombre = posicion.Nombre }, commandType: CommandType.StoredProcedure);
            return posicion;
        }

        public List<Posicion> ObtenerTodos()
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Posicion>("sp_Posicion_ObtenerTodos", commandType: CommandType.StoredProcedure).AsList();
        }

        public List<Jugador> ObtenerJugadoresPorPosicion(byte id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Jugador>("sp_Posicion_ObtenerJugadores", new { p_Id = id }, commandType: CommandType.StoredProcedure).AsList();
        }

        public Posicion? ObtenerPorId(byte id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<Posicion>("sp_Posicion_ObtenerPorId", new { p_Id = id }, commandType: CommandType.StoredProcedure);
        }

        public bool Eliminar(byte id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingle<int>("sp_Posicion_Eliminar", new { p_Id = id }, commandType: CommandType.StoredProcedure) > 0;
        }
    }
}