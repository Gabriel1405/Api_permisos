using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Input
{
    public class PermisosInput
    {
        public  int Id { get; set; }
        public  required string NombreEmpleado { get; set; }
        public required string ApellidoEmpleado { get; set; }
        public required int TipoPermiso { get; set; }        
    }
}
