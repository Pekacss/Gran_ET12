using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoEquipo : IRepoEquipo
    {
        private readonly DBConnection _dbConnection;

        public RepoEquipo(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Equipo> ObtenerTodos()
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Equipo>("sp_Equipo_ObtenerTodos", commandType: CommandType.StoredProcedure).AsList();
        }

        public Equipo? ObtenerPorId(byte id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<Equipo>("sp_Equipo_ObtenerPorId", new { p_Id = id }, commandType: CommandType.StoredProcedure);
        }

        public List<Jugador> ObtenerJugadoresPorEquipo(byte id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Jugador>(
                "sp_Equipo_ObtenerJugadores",
                new { p_Id = id },
                commandType: CommandType.StoredProcedure)
                .AsList();
        }

        public Equipo Agregar(Equipo equipo)
        {
            using var connection = _dbConnection.CrearConexion();
            equipo.Id = connection.QuerySingle<byte>("sp_Equipo_Agregar", new { p_Nombre = equipo.Nombre }, commandType: CommandType.StoredProcedure);
            return equipo;
        }

        public bool Eliminar(byte id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingle<int>("sp_Equipo_Eliminar", new { p_Id = id }, commandType: CommandType.StoredProcedure) > 0;
        }
    }
}