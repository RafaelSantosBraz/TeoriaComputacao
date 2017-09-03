using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplificacao_GLC_Novo
{
    class Simplificacoes
    {

        private static char vazio;

        public static char Vazio { get => vazio; set => vazio = value; }

        public Simplificacoes()
        {
            Vazio = '£';
        }

        public Gramatica simbolosInuteisParteI(Gramatica G)
        {
            Gramatica G1 = new Gramatica();
            G1.S = G.S;
            G1.T = G.T;
            int tamAnt;
            do
            {
                tamAnt = G1.V.Variaveis.Count;
                for (int posProd = 0; posProd < G.P.Producoes.Count; posProd++)
                {
                    bool aceito = true;
                    for (int pos = 3; pos < G.P.Producoes[posProd].Length; pos++)
                    {
                        if (!G.T.Terminais.Contains(G.P.Producoes[posProd][pos]) && !G1.V.Variaveis.Contains(G.P.Producoes[posProd][pos]) && G.P.Producoes[posProd][pos] != Vazio)
                        {
                            aceito = false;
                            break;
                        }
                    }
                    if (aceito)
                    {

                    }
                }                    
            } while (G1.V.Variaveis.Count != tamAnt);
            return G1;
        }

        public Gramatica simbolosInuteisParteII(Gramatica G1)
        {
            Gramatica G2 = new Gramatica();
            G2.V.inserirVariavel(G2.S);
            int tamAntV, tamAntT;
            do
            {
                tamAntV = G2.V.Variaveis.Count;
                tamAntT = G2.T.Terminais.Count;
                for (int posProd = 0; posProd < G1.P.Producoes.Count; posProd++)
                {
                    bool aceito = false;
                    if (G2.V.Variaveis.Contains(G1.P.Producoes[posProd][0]))
                    {
                        aceito = true;
                    }
                    if (aceito)
                    {
                        for (int pos = 3; pos < G1.P.Producoes[posProd].Length; pos++)
                        {
                            if (Char.IsUpper(G1.P.Producoes[posProd][pos]))
                            {
                                G2.V.inserirVariavel(G1.P.Producoes[posProd][pos]);
                            }
                        }
                        G2.P.inserirProducao(G1.P.Producoes[posProd]);
                        for (int i = 3; i < G1.P.Producoes[posProd].Length; i++)
                        {
                            if (Char.IsLower(G1.P.Producoes[posProd][i]))
                            {
                                G2.T.inserirTerminal(G1.P.Producoes[posProd][i]);
                            }
                        }
                    }
                }
            } while (G2.V.Variaveis.Count != tamAntV && G2.T.Terminais.Count != tamAntT);
            return G2;
        }

        public Gramatica simbolosInuteis(Gramatica G)
        {
            return simbolosInuteisParteII(simbolosInuteisParteI(G));
        }

        public Variavel producoesVaziasParteI(Gramatica G)
        {
            Variavel Vvazio = new Variavel();
            for (int posProd = 0; posProd < G.P.Producoes.Count; posProd++)
            {
                for (int pos = 3; pos < G.P.Producoes[posProd].Length; pos++)
                {
                    if (G.P.Producoes[posProd][pos] == Vazio)
                    {
                        Vvazio.inserirVariavel(G.P.Producoes[posProd][0]);
                    }
                }
            }
            int tamAnt;
            do
            {
                tamAnt = Vvazio.Variaveis.Count;
                for (int posProd = 0; posProd < G.P.Producoes.Count; posProd++)
                {
                    bool inserir = true;
                    for (int pos = 3; pos < G.P.Producoes[posProd].Length; pos++)
                    {
                        if (!Vvazio.Variaveis.Contains(G.P.Producoes[posProd][pos]))
                        {
                            inserir = false;
                            break;
                        }
                    }
                    if (inserir)
                    {
                        Vvazio.inserirVariavel(G.P.Producoes[posProd][0]);
                    }
                }
            } while (Vvazio.Variaveis.Count != tamAnt);
            return Vvazio;
        }

        public Gramatica producoesVaziasParteII(Gramatica G, Variavel Vvazio)
        {
            Gramatica G1 = new Gramatica();
            G1.S = G.S;
            G1.V = G.V;
            G1.T = G.T;
            for (int posProd = 0; posProd < G.P.Producoes.Count; posProd++)
            {
                for (int pos = 3; pos < G.P.Producoes[posProd].Length; pos++)
                {
                    if (G.P.Producoes[posProd][pos] != Vazio)
                    {
                        G1.P.inserirProducao(G.P.Producoes[posProd]);
                    }
                }
            }
            int tamAnt;
            do
            {
                tamAnt = G1.P.Producoes.Count;
                for (int posProd = 0; posProd < G1.P.Producoes.Count; posProd++)
                {
                    List<char> vars = new List<char>();
                    for (int pos = 3; pos < G1.P.Producoes[posProd].Length; pos++)
                    {
                        if (Vvazio.Variaveis.Contains(G1.P.Producoes[posProd][pos]))
                        {
                            vars.Add(G1.P.Producoes[posProd][pos]);
                        }
                    }
                    bool[,] tabela = tabelaVerdade(vars.Count);
                    for (int l = 0; l < tabela.GetLength(0); l++)
                    {
                        string novaProd = G1.P.Producoes[posProd];
                        novaProd = novaProd.Remove(0, 3);
                        for (int c = 0; c < tabela.GetLength(1); c++)
                        {
                            if (tabela[l, c])
                            {
                                int p = novaProd.IndexOf(vars[c]);
                                novaProd = novaProd.Remove(p, 1);
                            }
                        }
                        if (novaProd.Length != 0)
                        {
                            G1.P.inserirProducao(G1.P.Producoes[posProd][0] + "->" + novaProd);
                        }
                    }
                }
            } while (G1.P.Producoes.Count != tamAnt);
            return G1;
        }

        public bool[,] tabelaVerdade(int colunas)
        {
            int linhas = (int)Math.Pow(2, colunas);
            bool[,] tabela = new bool[linhas, colunas];
            int h = 1;
            for (int c = colunas - 1; c >= 0; c--)
            {
                int hAtual = 0;
                bool atual = false;
                for (int l = 0; l < linhas; l++)
                {
                    if (hAtual == h)
                    {
                        atual = !atual;
                        hAtual = 0;
                    }
                    tabela[l, c] = atual;
                    hAtual++;
                }
                h *= 2;
            }
            return tabela;
        }

        public Gramatica producoesVaziasParteIII(Gramatica G1, Variavel Vvazio)
        {
            Gramatica G2 = G1;
            if (Vvazio.Variaveis.Contains(G2.S))
            {
                G2.P.inserirProducao(G2.S + "->" + Simplificacoes.Vazio);
            }
            return G2;
        }

        public Gramatica producoesVazias(Gramatica G)
        {
            Variavel Vvazio = producoesVaziasParteI(G);
            Gramatica G1 = producoesVaziasParteII(G, Vvazio);
            return producoesVaziasParteIII(G1, Vvazio);
        }

        public ConjuntoFecho producoesSubsVariaveisI(Gramatica G)
        {
            ConjuntoFecho conjunto = new ConjuntoFecho();
            Variavel vars = new Variavel();
            for (int posProd = 0; posProd < G.P.Producoes.Count; posProd++)
            {
                vars.inserirVariavel(G.P.Producoes[posProd][0]);
            }
            for (int posVar = 0; posVar < vars.Variaveis.Count; posVar++)
            {
                Fecho fecho = fechoParcial(G, vars.Variaveis[posVar]);
                int tamAnt;
                do
                {
                    tamAnt = fecho.Subs.Count;
                    for (int p = 0; p < fecho.Subs.Count; p++)
                    {
                        Fecho fechoNovo = fechoParcial(G, fecho.Subs[p]);
                        for (int i = 0; i < fechoNovo.Subs.Count; i++)
                        {
                            fecho.inserirSubstituicao(fechoNovo.Subs[i]);
                        }
                    }
                } while (fecho.Subs.Count != tamAnt);
                conjunto.Fechos.Add(fecho);
            }
            return conjunto;
        }

        public Fecho fechoParcial(Gramatica G, char variavel)
        {
            Fecho fecho = new Fecho(variavel);
            for (int posProd = 0; posProd < G.P.Producoes.Count; posProd++)
            {
                if (variavel == G.P.Producoes[posProd][0])
                {
                    if (G.P.Producoes[posProd].Length == 4 && G.P.Producoes[posProd][3] != variavel && G.V.Variaveis.Contains(G.P.Producoes[posProd][3]))
                    {
                        fecho.inserirSubstituicao(G.P.Producoes[posProd][3]);
                    }
                }
            }
            return fecho;
        }

        public Gramatica producoesSubsVariaveisII(Gramatica G, ConjuntoFecho conjunto)
        {
            Gramatica G1 = new Gramatica();
            G1.S = G.S;
            G1.V = G.V;
            G1.T = G.T;
            for (int posProd = 0; posProd < G.P.Producoes.Count; posProd++)
            {
                if (G.P.Producoes[posProd].Length != 4 || (G.P.Producoes[posProd].Length == 4 && !G.V.Variaveis.Contains(G.P.Producoes[posProd][3])))
                {
                    G1.P.inserirProducao(G.P.Producoes[posProd]);
                }
            }
            for (int c = 0; c < conjunto.Fechos.Count; c++)
            {
                for (int i = 0; i < conjunto.Fechos[c].Subs.Count; i++)
                {
                    for (int pos = 0; pos < G1.P.Producoes.Count; pos++)
                    {
                        if (G1.P.Producoes[pos][0] == conjunto.Fechos[c].Subs[i])
                        {
                            string aux = conjunto.Fechos[c].Var + "->";
                            for (int j = 3; j < G1.P.Producoes[pos].Length; j++)
                            {
                                aux += G1.P.Producoes[pos][j];
                            }
                            G1.P.inserirProducao(aux);
                        }
                    }
                }
            }
            return G1;
        }

        public Gramatica producoesSubsVariaveis(Gramatica G)
        {
            return producoesSubsVariaveisII(G, producoesSubsVariaveisI(G));
        }
    }
}
