using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApiCore.DTO
{
    public class RetornoDTO
    {
        public RetornoDTO()
        {
            Messagem = new List<string>();
            Parametros = new List<string>();
        }
        public string Resposta { get; set; }
        public List<string> Messagem { get; set; }
        public string Rota { get; set; }
        public List<string> Parametros { get; set; }
    }
}
