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
            char[] vars = { 'A', 'B', 'C', 'D', 'E', 'F' };
            char[] terms = { 'x', 'y', 'z' };
            String[] prods = { "A->xBy", "A->C", "B->zCx", "B->CD", "C->E", "C->xA", "C->F", "D->EF", "D->Axy", "E->xyz", "E->B", "F->D", "F->xBC" };
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
            Gramatica G1 = simp.producoesSubsVariaveis(G);
            G1.exibirGramatica();
            Console.Read();
        }
    }
}
