using Repositories;

namespace TestRepositories
{
    public abstract class TestRepoBase
    {
        protected DBConnection _conexion;

        protected TestRepoBase()
        {
            _conexion = TestRepositorioSupport.CrearConexion();
        }
    }
}
