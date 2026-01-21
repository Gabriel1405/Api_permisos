using Application.Contracts;
using Application.Contracts.Input;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_N5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPermisosController : ControllerBase
    {
        private readonly ITipoPermisosService _tipopermisosService;

        public TipoPermisosController(ITipoPermisosService tipopermisosService)
        {
            _tipopermisosService = tipopermisosService;
        }

        [HttpPost]
        public void Insert([FromBody] TipoPermisosInput tipopermisos)
        {
            _tipopermisosService.Add(tipopermisos);
        }

        [HttpGet("ListarTiposPermisos")]
        public IActionResult ListarPermisos()
        {
            var result = _tipopermisosService.List();
            return Ok(result);
        }

    }
}
