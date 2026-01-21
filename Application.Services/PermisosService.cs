using Application.Contracts;
using Application.Contracts.Input;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Nodes;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Application.Services
{
    public class PermisosService:
        IPermisosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ElasticService _elasticService;

        public PermisosService(IUnitOfWork unitOfWork
            , ElasticService elasticService
                                          )
        {
            this._unitOfWork = unitOfWork;
            _elasticService = elasticService;
        }

        public async Task<int> Add(PermisosInput input)
        {
            var entity = new Permisos
            {
                NombreEmpleado = input.NombreEmpleado,
                ApellidoEmpleado = input.ApellidoEmpleado,
                TipoPermiso = input.TipoPermiso,
                Fecha = DateTime.Now
            };

            var id=_unitOfWork.Permisos.Insert(entity);

            var permisoElastic = new PermisosElastic
            {
                Id = id,
                NombreEmpleado = input.NombreEmpleado,
                ApellidoEmpleado = input.ApellidoEmpleado,
                TipoPermiso = input.TipoPermiso,
                Fecha = DateTime.Now
            };

            await _elasticService.InsertarAsync(permisoElastic);
            return id;
        }

        public async Task<int> Update(PermisosInput input)
        {
            var entity = _unitOfWork.Permisos.GetById(input.Id);

            if (entity == null)
                throw new Exception("Permiso no encontrado");

            entity.NombreEmpleado = input.NombreEmpleado;
            entity.ApellidoEmpleado = input.ApellidoEmpleado;
            entity.TipoPermiso = input.TipoPermiso;
            entity.Fecha = DateTime.Now;

            _unitOfWork.Permisos.Update(entity);


            var permisoElastic = new PermisosElastic
            {
                Id = entity.Id,
                NombreEmpleado = input.NombreEmpleado,
                ApellidoEmpleado = input.ApellidoEmpleado,
                TipoPermiso = input.TipoPermiso,
                Fecha = DateTime.Now
            };

            await _elasticService.ActualizarAsync(permisoElastic); 

            return entity.Id;
        }

        public IEnumerable<Permisos> List()
        {
            return _unitOfWork.Permisos.GetList();
        }


        public async Task<IEnumerable<PermisosElastic>> Listar()
        {
            return await _elasticService.ListarPermisosAsync();
        }




        /*public void Add(PermisosInput permisos)
        {
            var ruleInstance = _rules
                               .FirstOrDefault(x => x.
                          IsApplicable(permisos.Id));

            foreach (var rule in _rules)
            {
                rule.Process(permisos);
            }
        }*/
    }
}
