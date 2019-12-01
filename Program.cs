using System;
using System.Collections.Generic;
using AlgoritimoGeneticoString.Models;

namespace AlgoritimoGeneticoString
{
    class Program
    {
        static void Main(string[] args)
        {
            int geracao = 0;
            System.Console.WriteLine("Digite a frase a ser encontrada através da evolução: ");
            string frase = Console.ReadLine();
            List<Individuo> GrupoDeIndividuos = AlgoritimoGenetico.GerarPrimeirosIndividuos(10000,frase);

            while(AlgoritimoGenetico.HaUmVencedor(GrupoDeIndividuos) == false)
            {

                    System.Console.WriteLine("Geracao: "+geracao);
                    AlgoritimoGenetico algoritimo = new AlgoritimoGenetico();
                    GrupoDeIndividuos = algoritimo.SelecaoNatural(GrupoDeIndividuos);
                    geracao++;
                
                
                
            }
            
            System.Console.WriteLine("Acharam! isso é biologia na pratica! Programa criado por André Azevedo");
            


        }
    }
}
