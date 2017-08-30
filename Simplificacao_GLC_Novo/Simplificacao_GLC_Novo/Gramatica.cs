using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplificacao_GLC_Novo
{
    class Gramatica
    {
        private Variavel v;
        private Terminal t;
        private Producao p;
        private char s;

        public Gramatica()
        {
            V = new Variavel();
            T = new Terminal();
            P = new Producao();
            S = 'S';
        }

        public char S { get => s; set => s = value; }
        internal Variavel V { get => v; set => v = value; }
        internal Terminal T { get => t; set => t = value; }
        internal Producao P { get => p; set => p = value; }

        public void exibirGramatica()
        {
            Console.WriteLine("----");
            Console.WriteLine("V:");
            foreach (char var in this.V.Variaveis)
            {
                Console.WriteLine(" " + var);
            }
            Console.WriteLine("T:");
            foreach (char var in this.T.Terminais)
            {
                Console.WriteLine(" " + var);
            }
            Console.WriteLine("P:");
            foreach (String var in this.P.Producoes)
            {
                Console.WriteLine(" " + var);
            }
            Console.WriteLine("S:");
            Console.WriteLine(" " + this.S);
            Console.WriteLine("----");
        }
    }
}
