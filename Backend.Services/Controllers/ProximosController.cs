using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Backend.Models;

namespace Backend.Services.Controllers
{

    public class ProximosController : ApiController
    {

        /// <summary>Retorna todos os amigos próximos por ID.</summary>
        public IEnumerable<AmigoData> Post([FromBody]string token, [FromUri]int idAmigo)
        {

            // retorna todos os amigos proximos
            return this.Post(token, idAmigo, -1);

        }

        /// <summary>Retorna uma quantidade de amigos próximos por ID.</summary>
        public IEnumerable<AmigoData> Post([FromBody]string token, [FromUri]int idAmigo, [FromUri]int quantidade)
        {

            // verifica token de acesso
            Shared.VerificarToken(token);

            // inicializa contexto de dados
            DadosAmigos dados = new DadosAmigos();

            // retorna ou cria cache de distancia
            IQueryable<Cache> cache = dados.Caches.Where(entry => entry.IdAmigo == idAmigo);
            if (cache == null || cache.Count() == 0)
            {
                Shared.CreateCache(dados, idAmigo);
                cache = dados.Caches.Where(entry => entry.IdAmigo == idAmigo);
            }

            // retorna dados
            cache = cache.OrderBy(entry => entry.Distancia);
            if (quantidade != -1)
                cache = cache.Take(quantidade);
            cache.ForEach(entry => entry.DestinoReference.Load());

            // converte dados
            List<AmigoData> amigos = new List<AmigoData>();
            foreach (Amigo entry in cache.Select(entry => entry.Destino))
            {
                amigos.Add(entry.CopyProperties<AmigoData>());
            }
            return amigos;

        }

        /// <summary>Retorna uma quantidade de amigos próximos por latitude/longitude.</summary>
        public IEnumerable<AmigoData> Post([FromBody]string token, [FromUri]decimal latitude, [FromUri]decimal longitude, [FromUri]int quantidade)
        {

            // verifica token de acesso
            Shared.VerificarToken(token);

            // retorna o ID do amigo
            int id = Shared.GetId(latitude, longitude);

            // verifica se o amigo existe
            if (id == 0)
                return null;

            // retorna os próximos
            return this.Post(token, id, quantidade);

        }

    }

}
