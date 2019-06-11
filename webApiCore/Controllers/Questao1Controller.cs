using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiCore.DTO;
using webApiCore.Models;

namespace webApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Questao1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Questao1(int alvo, String texto)
        {
            if (texto != null)
            {
                RetornoDTO dto = new RetornoDTO();
                dto.Rota = Request.Path;
                dto.Parametros = Request.QueryString.Value.Split('?')[1].Split('&').ToList();
                List<int> lista = Tools.ConverterEmLista(texto);
                List<int> resultado = Questoes.Questao1(lista, alvo);

                if (resultado != null)
                {
                    dto.Messagem.Add("Indice nº 1 : " + resultado[0] + " (" + lista[resultado[0]] + ")");
                    dto.Messagem.Add("Indice nº 2 : " + resultado[1] + " (" + lista[resultado[1]] + ")");
                    dto.Messagem.Add("Para o Alvo : " + Convert.ToString(alvo));
                    dto.Resposta = "[" + resultado[0] + "," + resultado[1] + "]";
                }
                else
                {
                    dto.Messagem.Add("Não foi encontrada conbinação possivel para o Alvo informado ");
                }
                return Ok(dto);
            }
            else
            {
                return NotFound("Parametros não informados");
            }
        }
    }
}
