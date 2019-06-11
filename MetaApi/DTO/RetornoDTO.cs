using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetaApi.DTO
{
    public class RetornoDTO
    {
        public RetornoDTO()
        {
            Messagem = new List<string>();
        }
        public string Resposta { get; set; }
        public List<string> Messagem { get; set; }
        public string Rota { get; set; }
        public string Parametros { get; set; }
        


    }
}