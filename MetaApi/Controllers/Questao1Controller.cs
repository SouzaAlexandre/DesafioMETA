using MetaApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MetaApi.Controllers
{
    public class Questao1Controller : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get(int alvo, String texto)
        {
            RetornoDTO dto = new RetornoDTO();

            List<int> lista = Tools.ConverterEmLista(texto);            
            List<int> resultado = Questoes.Questao1(lista, alvo);

            if (resultado != null)
            {
                dto.Messagem.Add("Indice nº 1 : " + resultado[0] + " (" + lista[resultado[0]] + ")");
                dto.Messagem.Add("Indice nº 2 : " + resultado[1] + " (" + lista[resultado[1]] + ")");
                dto.Messagem.Add("Para o Alvo : " + Convert.ToString(alvo));
                dto.Resposta = "[" + resultado[0] + "," + resultado[1] + "]";
                dto.Rota = Request.RequestUri.AbsolutePath;
                dto.Parametros = Request.RequestUri.Query.Split('?')[1];

            }
            else
            {
                dto.Messagem.Add("Não foi encontrada conbinação possivel para o Alvo informado ");
            }
            return Ok(dto);
        }
    }
}
