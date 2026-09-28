using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoPlantillaTitular : IRepoPlantillaTitular
    {
        private readonly DBConnection _dbConnection;

        public RepoPlantillaTitular(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<PlantillaTitular> ObtenerTodos()
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<PlantillaTitular>("sp_PlantillaTitular_ObtenerTodos", commandType: CommandType.StoredProcedure).AsList();
        }

        public PlantillaTitular? ObtenerPorId(int id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<PlantillaTitular>("sp_PlantillaTitular_ObtenerPorId", new { p_Id = id }, commandType: CommandType.StoredProcedure);
        }

        public List<Jugador> ObtenerTitularesPlantilla(int id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Jugador>("sp_PlantillaTitular_ObtenerJugadores", new { p_Id = id }, commandType: CommandType.StoredProcedure).AsList();
        }

        public PlantillaTitular Agregar(PlantillaTitular plantillaTitular)
        {
            using var connection = _dbConnection.CrearConexion();
            plantillaTitular.Id = connection.QuerySingle<int>("sp_PlantillaTitular_Agregar", new
            {
                p_IdPlantilla = plantillaTitular.IdPlantilla,
                p_IdJugador = plantillaTitular.IdJugador
            }, commandType: CommandType.StoredProcedure);
            return plantillaTitular;
        }
        
        public bool Eliminar(int id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingle<int>("sp_PlantillaTitular_Eliminar", new { p_Id = id }, commandType: CommandType.StoredProcedure) > 0;
        }
    }
}