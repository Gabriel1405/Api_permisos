using Repositories;
using UnitOfWork;

namespace DataAccess
{
    public class ApplicationUnitOfWork : IUnitOfWork
    {
        public IPermisosRepository Permisos { get; private set; }
        public ITipoPermisosRepository TipoPermisos { get; private set; }

        public ApplicationUnitOfWork(string connectionString)
        {
            Permisos = new PermisosRepository(connectionString);
            TipoPermisos = new TipoPermisosRepository(connectionString);
        }
    }
}
