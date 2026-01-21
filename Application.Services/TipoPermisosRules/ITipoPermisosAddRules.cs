using Application.Contracts.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TipoPermisosRules
{
    public interface ITipoPermisosAddRules
    {
        bool IsApplicable(int Id);
        void Process(TipoPermisosInput tipopermisos);
    }
}
