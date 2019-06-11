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
    public class Questao2Controller : ControllerBase
    {
        // GET: api/Questao2
        [HttpGet]
        public IActionResult Questao2(string texto)
        {
            RetornoDTO dto = new RetornoDTO();
            dto.Rota = Request.Path;
            dto.Parametros = Request.QueryString.Value.Split('?').ToList();
            var resposta = Questoes.Questao2(texto);
            dto.Messagem.Add("Os brackets estão Balanceados? " + Questoes.Questao2(resposta));
            dto.Resposta = resposta;
            return Ok(dto);
        }
    }
}
