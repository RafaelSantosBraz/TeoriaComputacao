using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplificacao_GLC_Novo
{
    class Program
    {
        static void Main(string[] args)
        {
            Gramatica G = new Gramatica();
            char[] vars = { 'S', 'A', 'B', 'C' };
            char[] terms = { 'a', 'b', 'c' };
            String[] prods = { "S->aAa", "S->bBb", "A->a", "A->S", "C->c" };
            for (int i = 0; i < vars.Length; i++)
            {
                G.V.inserirVariavel(vars[i]);
            }
            for (int i = 0; i < terms.Length; i++)
            {
                G.T.inserirTerminal(terms[i]);
            }
            for (int i = 0; i < prods.Length; i++)
            {
                G.P.inserirProducao(prods[i]);
            }
            Simplificacoes simp = new Simplificacoes();
            Gramatica G2 = simp.simbolosInuteis(G);
            G.exibirGramatica();
            G2.exibirGramatica();
            Console.Read();
        }
    }
}
