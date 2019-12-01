using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritimoGeneticoString.Models
{
    public class AlgoritimoGenetico
    {
        public static List<Individuo> GerarPrimeirosIndividuos(int Quantidade, string Objetivo)
        {
            List<Individuo> GrupoDeIndividuos = new List<Individuo>();
            for(int i = 0; i < Quantidade; i++)
            {
                Individuo individuo = new Individuo(GerarStringAleatoria(Objetivo.Length),Objetivo);
                PontuarIndividuo(individuo);
                GrupoDeIndividuos.Add(individuo);
            }
            return GrupoDeIndividuos;
        }

        public static void PontuarIndividuo(Individuo individuo)
        {
            for(int i =0; i < individuo.StringDoIndividuo.Length; i++)
            {
                if(individuo.Objetivo[i] == individuo.StringDoIndividuo[i])
                {
                    individuo.Pontuacao++;
                }
            }
        }

        public static string GerarStringAleatoria(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz !@#$%¨&*()_+=-\"\',ãá?êóç.";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, tamanho).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }

        public static bool HaUmVencedor(List<Individuo> GrupoDeIndividuos)
        {
            foreach(Individuo Individuo in GrupoDeIndividuos)
            {
                if(Individuo.StringDoIndividuo == Individuo.Objetivo)
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("VENCEDOR: "+Individuo.StringDoIndividuo+" PAI DELE: "+Individuo.PaiString+" MAE DELE: "+Individuo.MaeString);
                    System.Console.WriteLine();
                    return true;
                }
            }
            return false;
        }
        public static string Crossover(string um, string dois)
        {
            Random rand = new Random();
            string resultado = "";

            for(int i = 0; i < um.Length; i++)
            {
                int randomico = rand.Next(0,102);
                
                if(randomico >= 50 && randomico <=100){ //TODO STRING UM DOMINANTE
                    resultado = resultado+um[i];
                }else if(randomico < 50){ //TODO STRING DOIS DOMINANTE
                    resultado = resultado+dois[i];
                }else if(randomico >= 100) //TODO MUTACAO
                {
                    resultado = resultado+GerarStringAleatoria(1);
                }
            }
            
            return resultado;
        }

        public List<Individuo> SelecaoNatural(List<Individuo> GrupoDeIndividuos)
        {
            
            GrupoDeIndividuos = GrupoDeIndividuos.OrderByDescending(c => c.Pontuacao).ToList();
            List<Individuo> FilhoGrupoDeIndividuos = new List<Individuo>();
            Random rand = new Random();
            string novaidentidade = "";
            for(int i = 0; i < GrupoDeIndividuos.Count; i++)
            {
                int randomico = rand.Next(0,100);
                novaidentidade = Crossover(GrupoDeIndividuos[randomico].StringDoIndividuo,GrupoDeIndividuos[i].StringDoIndividuo);
                Individuo individuo = new Individuo(novaidentidade, GrupoDeIndividuos[0].Objetivo);
                individuo.PaiString = GrupoDeIndividuos[randomico].StringDoIndividuo;
                individuo.MaeString = GrupoDeIndividuos[i].StringDoIndividuo;
                PontuarIndividuo(individuo);
                FilhoGrupoDeIndividuos.Add(individuo);
                
            }
            System.Console.WriteLine("MELHOR: "+FilhoGrupoDeIndividuos[0].StringDoIndividuo+" PAI DELE: "+FilhoGrupoDeIndividuos[0].PaiString+" MAE DELE: "+FilhoGrupoDeIndividuos[0].MaeString);
            return FilhoGrupoDeIndividuos;
        }
        public AlgoritimoGenetico()
        {

        }
    }
}