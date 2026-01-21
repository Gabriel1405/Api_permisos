using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Elastic.Clients.Elasticsearch.Nodes;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Transport;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ElasticService
    {
        private readonly ElasticsearchClient _client;
        private const string IndexName = "permisos";


        public ElasticService()
        {
            var settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
                 .Authentication(new BasicAuthentication("elastic", "f701Qbk9cDH=dZUEMcYz"))
                .DefaultIndex("permisos")
                .ServerCertificateValidationCallback((sender, certificate, chain, errors) => true); ; // índice por defecto
           
            _client = new ElasticsearchClient(settings);

            var ping = _client.Ping();
            Console.WriteLine($"Ping válido: {ping.IsValidResponse}");

            //Crear índice si no existe
            CrearIndiceSiNoExiste().GetAwaiter().GetResult();
        }

        public ElasticsearchClient Client => _client;


        private async Task CrearIndiceSiNoExiste()
        {
            var exists = await _client.Indices.ExistsAsync(IndexName);

            if (!exists.Exists)
            {
                var createIndexRequest = new CreateIndexRequest(IndexName)
                {                   
                };

                await _client.Indices.CreateAsync(createIndexRequest);
            }
        }

        public async Task InsertarAsync(PermisosElastic permiso)
        {
            await _client.IndexAsync(permiso);
        }

        public async Task ActualizarAsync(PermisosElastic permiso)
        {
            var request = new UpdateRequest<PermisosElastic, PermisosElastic>(IndexName, permiso.Id)
            {
                Doc = permiso,
                //DocAsUpsert = true // opcional: crea si no existe
            };

            var response = await _client.UpdateAsync<PermisosElastic, PermisosElastic>(request);
           
        }


        public async Task<IEnumerable<PermisosElastic>> ListarPermisosAsync()
        {
            var searchRequest = new SearchRequest<PermisosElastic>(IndexName)
            {
                Size = 1000,
                Query = new MatchAllQuery() 
            };

            var response = await _client.SearchAsync<PermisosElastic>(searchRequest);

            if (!response.IsValidResponse)
                throw new Exception("Error al listar en Elastic");

            return response.Documents;
        }
    }  


}
