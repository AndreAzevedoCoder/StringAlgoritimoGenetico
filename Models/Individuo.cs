using System;
using System.Linq;

namespace AlgoritimoGeneticoString.Models
{
    public class Individuo
    {
        public string StringDoIndividuo {get;set;}
        public uint Pontuacao {get;set;}
        public string Objetivo {get;set;}
        public string PaiString {get;set;}
        public string MaeString {get;set;}
        public Individuo( string stringdoindividuo ,string objetivo )
        {
            this.StringDoIndividuo = stringdoindividuo;
            this.Pontuacao = 0;
            this.Objetivo = objetivo;
        }
    }
}