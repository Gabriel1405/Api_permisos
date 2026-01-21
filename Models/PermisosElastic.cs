using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PermisosElastic
    {
        public int Id { get; set; }
        public required string NombreEmpleado { get; set; }
        public required string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime Fecha { get; set; }
    }
}
