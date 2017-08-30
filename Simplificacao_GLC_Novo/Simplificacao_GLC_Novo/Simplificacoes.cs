using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplificacao_GLC_Novo
{
    class Simplificacoes
    {

        public Gramatica simbolosInuteisParteI(Gramatica G)
        {
            Gramatica G1 = new Gramatica();
            int tamAnt;
            do
            {
                tamAnt = G1.V.Variaveis.Count;
                for (int posProd = 0; posProd < G.P.Producoes.Count; posProd++)
                {
                    bool aceito = false;
                    for (int pos = 3; pos < G.P.Producoes[posProd].Length; pos++)
                    {
                        if (G.T.Terminais.Contains(G.P.Producoes[posProd][pos]))
                        {
                            aceito = true;
                        }
                        else
                        {
                            if (G1.V.Variaveis.Contains(G.P.Producoes[posProd][pos]))
                            {
                                aceito = true;
                            }
                            else
                            {
                                aceito = false;
                                break;
                            }
                        }
                        
                    }
                    if (aceito)
                    {
                        G1.V.inserirVariavel(G.P.Producoes[posProd][0]);
                        G1.P.inserirProducao(G.P.Producoes[posProd]);
                    }
                }
            } while (G1.V.Variaveis.Count != tamAnt);
            return G1;
        }
    }
}
