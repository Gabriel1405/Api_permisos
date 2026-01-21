using API_N5;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TestsAPI_N5
{
    public class TestPermisos : TestBase
    {
        public TestPermisos(WebApplicationFactory<Program> factory)
        : base(factory)
        {
        }

        [Fact]
        public async Task GuardarPermisos()
        {
            var permisos = new
            {
                NombreEmpleado = "Gabriel",
                ApellidoEmpleado = "Villavicencio ",
                TipoPermiso = 1
            };

            var response = await _client.PostAsJsonAsync(
                "/api/permisos",
                permisos
            );

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ActulizarPermisos()
        {
            int permisoId = 16;

            var permisos = new
            {                
                NombreEmpleado = "Gabriel",
                ApellidoEmpleado = "Villavicencio Modificado",
                TipoPermiso = 1
            };

            var response = await _client.PutAsJsonAsync(
                $"/api/permisos/{permisoId}",
                permisos
            );

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task ListarTodosLosPermisos()
        {           
            var response = await _client.GetAsync("/api/permisos/listarPermisos");          
            response.EnsureSuccessStatusCode();
            
            var permisos = await response.Content.ReadFromJsonAsync<List<PermisosElastic>>();

            Assert.NotNull(permisos);          
            Assert.True(permisos.Count >= 0); 
        }
    }

}
