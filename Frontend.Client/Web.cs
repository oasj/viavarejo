using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.IO;
using Backend.Models;
using Newtonsoft.Json;
using System.Configuration;

namespace Client
{

    public class Web
    {

        private static string token = ConfigurationManager.AppSettings["AccessToken"];

        /// <summary>Executa método HTTP GET.</summary>
        public static T HttpGet<T>(string url)
        {

            // inicializa HTTP request
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            
            // grava dados no request
            string body = String.Format("\"{0}\"", Web.token);
            request.ContentLength = body.Length;
            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(body);
            }

            // recebe resposta
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string dados = reader.ReadToEnd();
            

            // converte JSON para objeto
            JsonTextReader json = new JsonTextReader(new StringReader(dados));
            JsonSerializer serializer = new JsonSerializer();
            return serializer.Deserialize<T>(json);

        }

    }

}
