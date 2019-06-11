using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApiCore.Models
{
    public class Questoes
    {
        public static List<int> Questao1(List<int> Lista, int alvo)
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

        public static String Questao2(String texto)
        {
            var AbreCochetes = texto.Split('[').Length - 1;
            var FechaCochetes = texto.Split(']').Length - 1;
            var AbreChaves = texto.Split('{').Length - 1;
            var FechaChaves = texto.Split('}').Length - 1;
            var AbreParenteses = texto.Split('(').Length - 1;
            var FechaParenteses = texto.Split(')').Length - 1;

            if (AbreCochetes == FechaCochetes && AbreChaves == FechaChaves && AbreParenteses == FechaParenteses)
                return "SIM";
            else
                return "Não";
        }


        public static string Questao3(List<int> Lista)
        {
            List<int> retorno = new List<int>();
            int lucro = 0;
            for (int i = 0; i < Lista.Count; i++)
            {
                for (int y = ++i; y < Lista.Count; y++)
                {
                    if (Lista[y] - Lista[i] > lucro)
                    {
                        lucro = Lista[y] - Lista[i];
                        VendaAcoes.DiaCompra = i + 1;
                        VendaAcoes.DiaVenda = y + 1;
                        VendaAcoes.ValorCompra = Lista[i];
                        VendaAcoes.ValorVenda = Lista[y];
                        VendaAcoes.Lucro = lucro;
                    }
                }
            }

            if (lucro > 0)
                return Convert.ToString(VendaAcoes.Lucro) + " (Comprou no dia " + Convert.ToString(VendaAcoes.DiaCompra) +
                        " (preço igual a " + Convert.ToString(VendaAcoes.ValorCompra) + ") e vendeu no dia " + Convert.ToString(VendaAcoes.DiaVenda) +
                        " (preço igual a " + Convert.ToString(VendaAcoes.ValorVenda) + "), lucro foi de "
                        + Convert.ToString(VendaAcoes.ValorVenda) + " – " + Convert.ToString(VendaAcoes.ValorCompra) + " = " + Convert.ToString(VendaAcoes.Lucro);
            else
                return Convert.ToString(lucro) + " (Nesse caso nenhuma transação deve ser feita, lucro máximo igual a " + Convert.ToString(lucro) + ")";
        }


        public static int Questao4(List<int> Lista)
        {
            IntevaloArmazenagem intevaloArmazenagem = new IntevaloArmazenagem();

            intevaloArmazenagem.limpar();
            int esquerda = Lista[0];
            for (int i = 0; i < Lista.Count; i++)
            {
                intevaloArmazenagem.Intervalo.Add(Lista[i]);
                if (Lista[i] > esquerda)
                {
                    intevaloArmazenagem.Calcular();
                    intevaloArmazenagem.limpar();
                    esquerda = Lista[i];
                    intevaloArmazenagem.Intervalo.Add(Lista[i]);
                }
                else if (i == Lista.Count - 1)
                {
                    intevaloArmazenagem.Calcular();
                }
            }
            return intevaloArmazenagem.ValorArmazenagem;
        }
    }

    public class IntevaloArmazenagem
    {
        public IntevaloArmazenagem()
        {
            Intervalo = new List<int>();
            totalizador = 0;
        }
        public List<int> Intervalo { get; set; }

        private int totalizador;

        public void Calcular()
        {
            int esquerda = Intervalo[0];
            if (Intervalo.Max() == Intervalo[0] && Intervalo[Intervalo.Count - 1] < Intervalo.Max())
            {
                esquerda = CalcularTopo();
            }

            int soma = 0;

            for (int i = 0; i < Intervalo.Count; i++)
            {
                if (esquerda > Intervalo[i])
                {
                    if (i != (Intervalo.Count - 1))
                    {
                        soma += esquerda - Intervalo[i];
                    }

                }
            }
            totalizador += soma;
        }


        private int CalcularTopo()
        {
            int topo = 0;
            int MaiorNumero = Intervalo.Max();
            if (MaiorNumero == Intervalo[0])
            {

                foreach (var item in Intervalo)
                {
                    if (item < MaiorNumero && topo < item)
                        topo = item;
                }
            }
            return topo;
        }

        public int ValorArmazenagem
        {
            get
            {
                return totalizador;
            }

        }
        public void limpar()
        {
            Intervalo.Clear();
        }
    }
    static class VendaAcoes
    {
        public static int Lucro { get; set; }
        public static int DiaCompra { get; set; }
        public static int ValorCompra { get; set; }
        public static int DiaVenda { get; set; }
        public static int ValorVenda { get; set; }
    }

    static class Tools
    {
        public static List<int> ConverterEmLista(String texto)
        {
            List<int> lista = new List<int>();
            foreach (var item in texto.Split(','))
            {
                lista.Add(Convert.ToInt32(item));
            };
            return lista;
        }

    }

}
