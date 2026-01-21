using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Output
{
    public class PermisosDTO
    {
        public PermisosDTO()
        {

        }
        public int Id { get; set; }
        public required string NombreEmpleado { get; set; }
        public required string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public string Permiso { get; set; }
        public DateTime Fecha { get; set; }
    }
}
