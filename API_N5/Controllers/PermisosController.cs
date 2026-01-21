using Application.Contracts;
using Application.Contracts.Input;
using Application.Contracts.Output;
using Application.Services;
using Elastic.Clients.Elasticsearch.MachineLearning;
using Microsoft.AspNetCore.Mvc;
using Models;
using UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_N5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly IPermisosService _permisosService;
        private readonly ITipoPermisosService _tipopermisosService;


        public PermisosController(IPermisosService permisosService, ITipoPermisosService tipopermisosService)
        {
            _permisosService = permisosService;
            _tipopermisosService = tipopermisosService;
        }

        // GET: api/<PermisosController>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] PermisosInput permisos)
        {
            //_permisosService.Add(permisos);
            var id = await _permisosService.Add(permisos);
            return Ok(new { Id = id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PermisosInput input)
        {            
            input.Id = id;
                       
            var result = await _permisosService.Update( input);
            return Ok(result);                                  
        }

        //[HttpGet("ListarPermisos")]
        //public IActionResult ListarPermisos()
        //{
        //    var result = _permisosService.List();
        //    return Ok(result);
        //}

        [HttpGet("listarPermisos")]
        public async Task<IEnumerable<PermisosElastic>> Listar()
        {
            return await _permisosService.Listar();
        }


    }
}
