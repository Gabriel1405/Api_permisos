using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Input
{
    public class TipoPermisosInput
    {
        public int Id { get; set; }
        public required string Descripcion { get; set; }
    }
}
