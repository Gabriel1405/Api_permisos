using Application.Contracts.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PermisosRules
{
    public abstract class PermisosSaveBase:
        IPermisosAddRules
    {
        //public abstract bool IsApplicable(int Id);
        public void Process(PermisosInput permisos)
        {
            ExecuteSave(permisos);
        }
        public abstract void ExecuteSave(PermisosInput permisos);



    }
}
