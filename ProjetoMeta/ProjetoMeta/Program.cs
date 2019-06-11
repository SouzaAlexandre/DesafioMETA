using System;
using System.Collections.Generic;

namespace ProjetoMeta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! {0}");
            string line = Console.ReadLine();
          
            Executar();
        }







        static void Executar()
        {

            List<int> lista = new List<int> { 2, 7, 11, 15};
            List<int> resultado = Questoes.Questao1(lista, 9);
            if (resultado != null)
            {
                foreach (var item in Questoes.Questao1(lista, 9))
                {
                    Console.WriteLine("Indice : " + item);
                }
            }
            else
            {
                Console.WriteLine("Não foi encontrada conbinação possivel para o Alvo informado ");
            }
        }




}






}
