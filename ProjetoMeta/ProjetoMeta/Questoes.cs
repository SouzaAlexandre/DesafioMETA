using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMeta
{
    public static class Questoes
    {

        public static List<int>  Questao1(List<int> Lista, int alvo)
        {
            List<int> retorno = new List<int>();

            for (int i = 0; i < Lista.Count; i++)
            {
                for (int y = i++; y < Lista.Count; y++)
                {
                    if ((Lista[i] + Lista[y] == alvo))
                    {
                        retorno.Add(i);
                        retorno.Add(y);
                        retorno.Sort();
                        return retorno;
                    }
                }
            }

            return null;
        }

    }
}
