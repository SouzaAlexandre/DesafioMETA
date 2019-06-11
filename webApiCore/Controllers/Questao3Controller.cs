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
    public class Questao3Controller : ControllerBase
    {
        // GET: api/Questao3
        [HttpGet]
        public IActionResult Questao3(string texto)
        {
            RetornoDTO dto = new RetornoDTO();
            dto.Rota = Request.Path;
            dto.Parametros = Request.QueryString.Value.Split('?').ToList();
            var resposta = Questoes.Questao3(Tools.ConverterEmLista(texto));
            dto.Messagem.Add(resposta);
            dto.Resposta = resposta;
            return Ok(dto);
        }
    }
}
