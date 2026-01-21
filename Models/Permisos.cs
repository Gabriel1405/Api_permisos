using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Models
{                                     
    public class Permisos
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string NombreEmpleado { get; set; }
        public required string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }                                           
        [Computed]
        public virtual TipoPermisos TipoPermisos { get; set; }
        public DateTime Fecha {  get; set; }                                                                                                                                                                                                                                                                                                                                      
    }
}
                                                                                                                                                                                                                                             