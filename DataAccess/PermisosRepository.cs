using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using Repositories;
using Application.Contracts.Output;

namespace DataAccess
{
    public class PermisosRepository :
        RepositoryBase<Permisos>, IPermisosRepository
    {
        public PermisosRepository(string connectionString)
          : base(connectionString)
        {
        }
        public IEnumerable<PermisosDTO> ListPermisos()
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = @"
            SELECT p.Id, p.NombreEmpleado, p.ApellidoEmpleado, p.Fecha,
                   p.TipoPermiso AS TipoPermisoId,
                   t.Descripcion AS NombreTipoPermiso
            FROM Permisos p
            INNER JOIN TipoPermisos t ON p.TipoPermiso = t.Id
            ORDER BY p.Fecha DESC
        ";

            return connection.Query<PermisosDTO>(sql);
        }
    }
}
