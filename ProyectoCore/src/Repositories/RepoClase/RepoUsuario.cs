using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;
using Interfaces;

namespace Repositories
{
    public class RepoUsuario : IRepoUsuario
    {
        private readonly DBConnection _dbConnection;

        public RepoUsuario(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Usuario Agregar(Usuario usuario)
        {
            using var connection = _dbConnection.CrearConexion();
            usuario.Id = connection.QuerySingle<ushort>("sp_Usuario_Agregar", new
            {
                p_Nombre = usuario.Nombre,
                p_Apellido = usuario.Apellido,
                p_Email = usuario.Email,
                p_FechaNacimiento = usuario.FechaNacimiento,
                p_Administrador = usuario.Administrador,
                p_Contrasena = usuario.Contraseña
            }, commandType: CommandType.StoredProcedure);
            return usuario;
        }

        public List<Usuario> ObtenerTodos()
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.Query<Usuario>("sp_Usuario_ObtenerTodos", commandType: CommandType.StoredProcedure).AsList();
        }

        public Usuario? ObtenerPorId(ushort id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<Usuario>("sp_Usuario_ObtenerPorId", new { p_Id = id }, commandType: CommandType.StoredProcedure);
        }

        public Usuario? ObtenerPorEmail(string email)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingleOrDefault<Usuario>("sp_Usuario_ObtenerPorEmail", new { p_Email = email }, commandType: CommandType.StoredProcedure);
        }

        public bool Eliminar(ushort id)
        {
            using var connection = _dbConnection.CrearConexion();
            return connection.QuerySingle<int>("sp_Usuario_Eliminar", new { p_Id = id }, commandType: CommandType.StoredProcedure) > 0;
        }
    }
}