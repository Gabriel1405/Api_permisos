using Application.Contracts.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PermisosRules
{
    public interface IPermisosAddRules
    {
        //bool IsApplicable(int Id);
        void Process(PermisosInput permisos);
    }
}
