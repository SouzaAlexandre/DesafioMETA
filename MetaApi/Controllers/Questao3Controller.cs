using MetaApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MetaApi.Controllers
{
    public class Questao3Controller : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string texto)
        {
            RetornoDTO dto = new RetornoDTO();
            var rota = Request.RequestUri;
            dto.Rota = Request.RequestUri.AbsolutePath;
            dto.Parametros = Request.RequestUri.Query.Split('?')[1];
            var resposta = Questoes.Questao3(Tools.ConverterEmLista(texto));
            dto.Messagem.Add(resposta);
            dto.Resposta = resposta;
            return Ok(dto);
        }
    }
}
