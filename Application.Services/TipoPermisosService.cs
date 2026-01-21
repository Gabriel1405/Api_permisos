using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Contracts;
using Application.Contracts.Input;
using Application.Contracts.Output;
using Models;
using UnitOfWork;

namespace Application.Services
{
    public class TipoPermisosService:
        ITipoPermisosService
    {
        private readonly IUnitOfWork _unitOfWork;                

        public TipoPermisosService(IUnitOfWork unitOfWork                            
                               )
        {
            _unitOfWork = unitOfWork;                        
        }

        public void Add(TipoPermisosInput input)
        {
            var entity = new TipoPermisos
            {
                Descripcion = input.Descripcion,                
            };

            _unitOfWork.TipoPermisos.Insert(entity);
        }

        public IEnumerable<TipoPermisos> List()
        {
            return _unitOfWork.TipoPermisos.GetList();
        }

    }
}
