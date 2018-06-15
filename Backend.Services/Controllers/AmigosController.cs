using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Backend.Models;
using System.Configuration;

namespace Backend.Services.Controllers
{

    public class AmigosController : ApiController
    {

        /// <summary>Retorna a lista de amigos.</summary>
        public IEnumerable<AmigoData> Post([FromBody]string token)
        {

            // verifica token de acesso
            Shared.VerificarToken(token);

            // inicializa contexto de dados
            DadosAmigos dados = new DadosAmigos();

            // retorna a lista de amigo
            List<AmigoData> amigos = new List<AmigoData>();
            foreach (Amigo entry in dados.Amigos)
            {
                amigos.Add(entry.CopyProperties<AmigoData>());
            }
            return amigos;

        }

        /// <summary>Retorna um amigo por ID.</summary>
        public AmigoData Post([FromBody]string token, [FromUri]int idAmigo)
        {

            // verifica token de acesso
            Shared.VerificarToken(token);

            // inicializa contexto de dados
            DadosAmigos dados = new DadosAmigos();

            // retorna o amigo
            return dados.Amigos.Where(entry => entry.IdAmigo == idAmigo).SingleOrDefault().CopyProperties<AmigoData>();

        }

        /// <summary>Retorna um amigo por latitude/longitude.</summary>
        public AmigoData Post([FromBody]string token, [FromUri]decimal latitude, [FromUri]decimal longitude)
        {

            // verifica token de acesso
            Shared.VerificarToken(token);

            // inicializa contexto de dados
            DadosAmigos dados = new DadosAmigos();

            // retorna o amigo
            return dados.Amigos.Where(entry => entry.Latitude == latitude && entry.Longitude == longitude).SingleOrDefault().CopyProperties<AmigoData>();

        }

        /// <summary>Cria ou altera um amigo.</summary>
        public void Put([FromBody]string token, [FromBody]AmigoData amigo)
        {

            // verifica token de acesso
            Shared.VerificarToken(token);

            // inicializa contexto de dados
            DadosAmigos dados = new DadosAmigos();

            // verifica se amigo ja existe
            Amigo entity = dados.Amigos.Where(entry => entry.IdAmigo == amigo.IdAmigo).SingleOrDefault();

            // cria ou altera o amigo
            if (entity == null)
            {

                // adiciona amigo
                entity = amigo.CopyProperties<Amigo>();
                dados.Amigos.AddObject(entity);

                //armazena alterações
                dados.SaveChanges();

                // recria cache
                Shared.CreateCache(dados, entity.IdAmigo);

            }
            else
            {

                // verifica se a latitude/longitude mudou
                bool recriarCache = false;
                if (entity.Latitude != amigo.Latitude ||
                    entity.Longitude != amigo.Longitude)
                {
                    recriarCache = true;
                }

                // altera atributos do amigo
                entity.Nome = amigo.Nome;
                entity.Local = amigo.Local;
                entity.Latitude = amigo.Latitude;
                entity.Longitude = amigo.Longitude;

                //armazena alterações
                dados.SaveChanges();

                // recria cache
                if (recriarCache)
                    Shared.CreateCache(dados, entity.IdAmigo);

            }

        }

        /// <summary>Apaga um amigo.</summary>
        public void Delete([FromBody]string token, [FromUri]int idAmigo)
        {

            // verifica token de acesso
            Shared.VerificarToken(token);

            // inicializa contexto de dados
            DadosAmigos dados = new DadosAmigos();

            // apaga cache
            Shared.ClearCache(dados, idAmigo);

            // apaga amigos
            IQueryable<Amigo> amigos = dados.Amigos.Where(entry => entry.IdAmigo == idAmigo);
            amigos.ForEach(entry => dados.DeleteObject(entry));

            //armazena alterações
            dados.SaveChanges();

        }

    }

}
