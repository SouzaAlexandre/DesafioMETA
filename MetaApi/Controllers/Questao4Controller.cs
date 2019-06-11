using MetaApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MetaApi.Controllers
{
    public class Questao4Controller : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string texto)
        {
            RetornoDTO dto = new RetornoDTO();
            var rota = Request.RequestUri;
            dto.Rota = Request.RequestUri.AbsolutePath;
            dto.Parametros = Request.RequestUri.Query.Split('?')[1];
            var resposta = Questoes.Questao4(Tools.ConverterEmLista(texto));
            dto.Messagem.Add("Capacidade de armazenagem de água é de " + Convert.ToString(resposta));
            dto.Resposta = Convert.ToString(resposta);
            return Ok(dto);
        }
    }
}
