using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;
using Models;
using Application.Contracts.Input;

namespace Application.Services.TipoPermisosRules
{
    public class TipoPermisosSaveSql: TipoPermisosSaveBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TipoPermisosSaveSql(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public override bool IsApplicable(int Id)
        {
            //if (CustomerId.StartsWith("S"))
            //{
            //    return true;
            //}
            //return false;
            return true;
        }

        public override void ExecuteSave(TipoPermisosInput tipopermisos)
        {
            _unitOfWork.TipoPermisos.Insert(
               new TipoPermisos()
               {
                   Descripcion = tipopermisos.Descripcion
               }
               );
        }

    }
}
