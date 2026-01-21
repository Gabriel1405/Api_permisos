using Dapper;
using Models;
using Repositories;
using System.Data.SqlClient;

namespace DataAccess
{
    public class TipoPermisosRepository:
         RepositoryBase<TipoPermisos>, ITipoPermisosRepository
    {
        public TipoPermisosRepository(string connectionString)
          : base(connectionString)
        {
        }

    }
}
