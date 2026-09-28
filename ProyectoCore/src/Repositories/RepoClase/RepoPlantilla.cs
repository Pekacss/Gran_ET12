using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoPlantilla : IRepoPlantilla
    {
        private readonly DBConnection _dbConnection;

        public RepoPlantilla(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Plantilla> ObtenerTodos()
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Plantilla>("sp_Plantilla_ObtenerTodos", commandType: CommandType.StoredProcedure).AsList();
        }
        public Plantilla? ObtenerPorIdUsuario(ushort id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<Plantilla>("sp_Plantilla_ObtenerPorUsuario", new { p_IdUsuario = id }, commandType: CommandType.StoredProcedure);
        }

        public Plantilla? ObtenerPorFecha(byte fecha)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<Plantilla>("sp_Plantilla_ObtenerPorFecha", new { p_Fecha = fecha }, commandType: CommandType.StoredProcedure);
        }

        public Plantilla? ObtenerPorNombre(string nombre)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<Plantilla>("sp_Plantilla_ObtenerPorNombre", new { p_Nombre = nombre }, commandType: CommandType.StoredProcedure);
        }
    
        public Plantilla? ObtenerPorId(int id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<Plantilla>("sp_Plantilla_ObtenerPorId", new { p_Id = id }, commandType: CommandType.StoredProcedure);
        }

        public List<Jugador> ObtenerJugadoresPorPlantilla(int id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Jugador>("sp_Plantilla_ObtenerJugadores", new { p_Id = id }, commandType: CommandType.StoredProcedure).AsList();
        }

        public decimal ObtenerCalificacionPlantilla(int id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingle<decimal>("sp_Plantilla_ObtenerCalificacion", new { p_Id = id }, commandType: CommandType.StoredProcedure);
        }

        public Plantilla Agregar(Plantilla plantilla)
        {
            using var connection = _dbConnection.CrearConexion();
            plantilla.Id = connection.QuerySingle<int>("sp_Plantilla_Agregar", new
            {
                p_IdUsuario = plantilla.IdUsuario,
                p_Fecha = plantilla.Fecha,
                p_Nombre = plantilla.Nombre
            }, commandType: CommandType.StoredProcedure);
            return plantilla;
        }

        public bool Eliminar(int id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingle<int>("sp_Plantilla_Eliminar", new { p_Id = id }, commandType: CommandType.StoredProcedure) > 0;
        }
    }
}