using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Backend.Models;
using System.Configuration;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace Backend.Services
{
    
    public static class Shared
    {

        /// <summary>Retorna o ID de um amigo por latitude/longitude.</summary>
        public static int GetId(decimal latitude, decimal longitude)
        {

            // inicializa contexto de dados
            DadosAmigos dados = new DadosAmigos();

            // retorna o amigo
            Amigo amigo = dados.Amigos.Where(entry => entry.Latitude == latitude && entry.Longitude == longitude).SingleOrDefault();
            return (amigo == null ? 0 : amigo.IdAmigo);

        }

        /// <summary>Apaga o log de cálculo de distâncias de um amigo.</summary>
        public static void ClearLog(DadosAmigos dados, int idAmigo)
        {

            // apaga log
            IQueryable<long> cache = dados.Caches.Where(entry => entry.IdAmigo == idAmigo || entry.IdDestino == idAmigo).Select(entry => entry.IdCache);
            IQueryable<Log> log = dados.Logs.Where(entry => cache.Contains(entry.IdCache));
            log.ForEach(entry => dados.DeleteObject(entry));

        }

        /// <summary>Apaga o cache de cálculo de distâncias de um amigo.</summary>
        public static void ClearCache(DadosAmigos dados, int idAmigo)
        {

            // apaga log
            Shared.ClearLog(dados, idAmigo);

            // apaga cache
            IQueryable<Cache> cache = dados.Caches.Where(entry => entry.IdAmigo == idAmigo || entry.IdDestino == idAmigo);
            cache.ForEach(entry => dados.DeleteObject(entry));

        }

        /// <summary>Cria o cache de cálculo de distâncias de um amigo.</summary>
        public static void CreateCache(DadosAmigos dados, int idAmigo)
        {

            // apaga cache
            Shared.ClearCache(dados, idAmigo);

            // retorna amigos
            List<Amigo> amigos = dados.Amigos.ToList();
            Amigo amigo = amigos.Where(entry => entry.IdAmigo == idAmigo).SingleOrDefault();

            // verifica se amigo existe
            if (amigo == null)
                return;

            // remove o amigo de origem da coleção
            amigos.Remove(amigo);

            // enumera amigos de destino
            amigos.ForEach(entry =>
            {

                Utilities.CalculoDistancia calculo = Utilities.Distance((double)amigo.Latitude, (double)amigo.Longitude, (double)entry.Latitude, (double)entry.Longitude);

                // cria cache direto
                Cache cache = new Cache()
                {
                    IdAmigo = entry.IdAmigo,
                    IdDestino = idAmigo,
                    Distancia = new Decimal(calculo.Kilometros)
                };

                // cria log do cálculo
                cache.Log = new Log()
                {
                    RadianosLatitudeOrigem = new Decimal(calculo.RadianosOrigem),
                    RadianosLatitudeDestino = new Decimal(calculo.RadianosDestino),
                    RadianosThetaLongitude = new Decimal(calculo.RadianosTheta),
                    Seno = new Decimal(calculo.Seno),
                    Coseno = new Decimal(calculo.Coseno),
                    Angulo = new Decimal(calculo.Angulo),
                    Milhas = new Decimal(calculo.Milhas),
                    Kilometros = new decimal(calculo.Kilometros)
                };

                // adiciona cache
                dados.Caches.AddObject(cache);

                // cria cache reverso
                cache = new Cache()
                {
                    IdAmigo = idAmigo,
                    IdDestino = entry.IdAmigo,
                    Distancia = new Decimal(calculo.Kilometros)
                };

                // cria log do cálculo
                cache.Log = new Log()
                {
                    RadianosLatitudeOrigem = new Decimal(calculo.RadianosOrigem),
                    RadianosLatitudeDestino = new Decimal(calculo.RadianosDestino),
                    RadianosThetaLongitude = new Decimal(calculo.RadianosTheta),
                    Seno = new Decimal(calculo.Seno),
                    Coseno = new Decimal(calculo.Coseno),
                    Angulo = new Decimal(calculo.Angulo),
                    Milhas = new Decimal(calculo.Milhas),
                    Kilometros = new decimal(calculo.Kilometros)
                };

                // adiciona cache
                dados.Caches.AddObject(cache);

            });

            //armazena alterações
            dados.SaveChanges();

        }

        // verifica token de acesso
        public static void VerificarToken(string token)
        {

            // verifica token
            if (token != ConfigurationManager.AppSettings["AccessToken"])
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));

        }

    }

}