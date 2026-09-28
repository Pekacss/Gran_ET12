using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoJugador : IRepoJugador
    {
        private readonly DBConnection _dbConnection;

        public RepoJugador(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Jugador> ObtenerTodos()
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Jugador>("sp_Jugador_ObtenerTodos", commandType: CommandType.StoredProcedure).AsList();
        }

        public Jugador? ObtenerPorId(ushort id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<Jugador>("sp_Jugador_ObtenerPorId", new { p_Id = id }, commandType: CommandType.StoredProcedure);
        }

        public Equipo? ObtenerEquipoPorJugador(ushort id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<Equipo>("sp_Jugador_ObtenerEquipo", new { p_Id = id }, commandType: CommandType.StoredProcedure);
        }

        public Posicion? ObtenerPosicionPorJugador(ushort id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<Posicion>("sp_Jugador_ObtenerPosicion", new { p_Id = id }, commandType: CommandType.StoredProcedure);
        }

        public Jugador Agregar(Jugador jugador)
        {
            using var connection = _dbConnection.CrearConexion();
            jugador.Id = connection.QuerySingle<ushort>("sp_Jugador_Agregar", new
            {
                p_Nombre = jugador.Nombre,
                p_Apellido = jugador.Apellido,
                p_Apodo = jugador.Apodo,
                p_FechaNacimiento = jugador.FechaNacimiento,
                p_IdEquipo = jugador.IdEquipo,
                p_Cotizacion = jugador.Cotizacion,
                p_IdPosicion = jugador.IdPosicion
            }, commandType: CommandType.StoredProcedure);
            return jugador;
        }
        
        public bool Eliminar(ushort id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingle<int>("sp_Jugador_Eliminar", new { p_Id = id }, commandType: CommandType.StoredProcedure) > 0;
        }
    }
}