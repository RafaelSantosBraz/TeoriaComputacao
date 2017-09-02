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
            int tamAnt;
            do
            {
                tamAnt = G1.V.Variaveis.Count;
                for (int posProd = 0; posProd < G.P.Producoes.Count; posProd++)
                {
                    bool aceito = false;
                    for (int pos = 3; pos < G.P.Producoes[posProd].Length; pos++)
                    {
                        if (G.T.Terminais.Contains(G.P.Producoes[posProd][pos]) || G.P.Producoes[posProd][pos] == Vazio)
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
                        for (int i = 3; i < G.P.Producoes[posProd].Length; i++)
                        {
                            if (Char.IsLower(G.P.Producoes[posProd][i]))
                            {
                                G1.T.inserirTerminal(G.P.Producoes[posProd][i]);
                            }
                        }
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
    }
}
