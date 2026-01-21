using Application.Contracts.Input;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Application.Services.PermisosRules
{
    public class PermisosSaveSql:PermisosSaveBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermisosSaveSql(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }        

        public override void ExecuteSave(PermisosInput input)
        {
            var permisos = new Permisos
            {
                NombreEmpleado = input.NombreEmpleado,
                ApellidoEmpleado = input.ApellidoEmpleado,
                TipoPermiso = input.TipoPermiso,
                Fecha = DateTime.Now
            };          
            _unitOfWork.Permisos.Insert(permisos);                           
        }

       


    }
}
