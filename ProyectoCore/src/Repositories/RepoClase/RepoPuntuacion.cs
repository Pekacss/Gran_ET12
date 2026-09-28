using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoPuntuacion : IRepoPuntuacion
    {
        private readonly DBConnection _dbConnection;

        public RepoPuntuacion(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Puntuacion Agregar(Puntuacion puntuacion)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingle<Puntuacion>("sp_Puntuacion_Agregar", new
            {
                p_Fecha = puntuacion.Fecha,
                p_IdJugador = puntuacion.IdJugador,
                p_Puntaje = puntuacion.Puntaje
            }, commandType: CommandType.StoredProcedure);
        }

        public List<Puntuacion> ObtenerTodos()
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Puntuacion>("sp_Puntuacion_ObtenerTodos", commandType: CommandType.StoredProcedure).AsList();
        }

        public List<Puntuacion> ObtenerPorFecha(byte fecha)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Puntuacion>("sp_Puntuacion_ObtenerPorFecha", new { p_Fecha = fecha }, commandType: CommandType.StoredProcedure).AsList();
        }

        public List<Puntuacion> ObtenerPorJugador(ushort id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Puntuacion>("sp_Puntuacion_ObtenerPorJugador", new { p_IdJugador = id }, commandType: CommandType.StoredProcedure).AsList();
        }

        public Puntuacion? ObtenerPorFechaJugador(byte fecha, ushort id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<Puntuacion>("sp_Puntuacion_ObtenerPorFechaJugador", new
            {
                p_Fecha = fecha,
                p_IdJugador = id
            }, commandType: CommandType.StoredProcedure);
        }

        public bool Eliminar(byte fecha, ushort idJugador)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingle<int>("sp_Puntuacion_Eliminar", new
            {
                p_Fecha = fecha,
                p_IdJugador = idJugador
            }, commandType: CommandType.StoredProcedure) > 0;
        }
    }
}