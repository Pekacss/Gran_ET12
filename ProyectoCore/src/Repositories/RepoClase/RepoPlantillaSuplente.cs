using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoPlantillaSuplente : IRepoPlantillaSuplente
    {
        private readonly DBConnection _dbConnection;

        public RepoPlantillaSuplente(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<PlantillaSuplente> ObtenerTodos()
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<PlantillaSuplente>("sp_PlantillaSuplente_ObtenerTodos", commandType: CommandType.StoredProcedure).AsList();
        }

        public PlantillaSuplente? ObtenerPorId(int id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<PlantillaSuplente>("sp_PlantillaSuplente_ObtenerPorId", new { p_Id = id }, commandType: CommandType.StoredProcedure);
        }

        public List<Jugador> ObtenerSuplentesPlantilla(int id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Jugador>("sp_PlantillaSuplente_ObtenerJugadores", new { p_Id = id }, commandType: CommandType.StoredProcedure).AsList();
        }

        public PlantillaSuplente Agregar(PlantillaSuplente plantillaSuplente)
        {
            using var connection = _dbConnection.CrearConexion();
            plantillaSuplente.Id = connection.QuerySingle<int>("sp_PlantillaSuplente_Agregar", new
            {
                p_IdPlantilla = plantillaSuplente.IdPlantilla,
                p_IdJugador = plantillaSuplente.IdJugador
            }, commandType: CommandType.StoredProcedure);
            return plantillaSuplente;
        }

        public bool Eliminar(int id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingle<int>("sp_PlantillaSuplente_Eliminar", new { p_Id = id }, commandType: CommandType.StoredProcedure) > 0;
        }
    }
}