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
            // o "£" (libra) representa o símbolo de Vazio
            Gramatica G = new Gramatica();
            char[] vars = { 'S', 'X' };
            char[] terms = { 'a', 'b' };
            String[] prods = { "S->aXb", "S->bXb", "X->a", "X->b", "X->S", "X->£" };
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
            //Gramatica G2 = simp.simbolosInuteis(G);     
            ConjuntoFecho c = simp.producoesSubsVariaveisI(G);
            Gramatica G1 = simp.producoesVazias(G);
            G1.exibirGramatica();
            Console.Read();
        }
    }
}
