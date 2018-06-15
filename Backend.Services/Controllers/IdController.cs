using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Services.Controllers
{

    public class IdController : ApiController
    {

        /// <summary>Retorna o ID de um amigo por latitude/longitude.</summary>
        public int Post([FromBody]string token, [FromUri]decimal latitude, [FromUri]decimal longitude)
        {

            // verifica token de acesso
            Shared.VerificarToken(token);

            // retorna o ID do amigo
            return Shared.GetId(latitude, longitude);

        }

    }

}
