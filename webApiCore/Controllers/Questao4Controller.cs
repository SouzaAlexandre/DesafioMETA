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
    public class Questao4Controller : ControllerBase
    {
        // GET: api/Questao4
        [HttpGet]
        [HttpGet]
        public IActionResult Questao4(string texto)
        {
            RetornoDTO dto = new RetornoDTO();
            dto.Rota = Request.Path;
            dto.Parametros = Request.QueryString.Value.Split('?').ToList();
            var resposta = Questoes.Questao4(Tools.ConverterEmLista(texto));
            dto.Messagem.Add("Capacidade de armazenagem de água é de " + Convert.ToString(resposta));
            dto.Resposta = Convert.ToString(resposta);
            return Ok(dto);
        }
    }
}
