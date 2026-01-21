using Application.Contracts.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TipoPermisosRules
{
    public abstract class TipoPermisosSaveBase:ITipoPermisosAddRules
    {
        public abstract bool IsApplicable(int Id);
        public void Process(TipoPermisosInput tipopermisos)
        {
            ExecuteSave(tipopermisos);
        }
        public abstract void ExecuteSave(TipoPermisosInput tipopermisos);
    }
}
