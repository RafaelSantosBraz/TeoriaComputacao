#include "Simplificacoes.hpp"

void inializarGramatica(GRAMATICA *G) // inicializar a gramática com os valores iniciais
{
    G->S = 'S';
    G->V.clear();
    G->T.clear();
    G->P.clear();
}

void inserirVariavel(GRAMATICA *G, string vars)
{
    for (int c = 0; c < vars.length(); c++)
    {
        G->V.push_back(vars[c]);
    }
}

void inserirTerminal(GRAMATICA *G, string terms)
{
    for (int c = 0; c < terms.length(); c++)
    {
        G->T.push_back(terms[c]);
    }
}

void inserirProducao(GRAMATICA *G, string producao)
{
    G->P.push_back(producao);
}

GRAMATICA* simbolosInuteisEtapa1(GRAMATICA *G)
{
    GRAMATICA *G1 = (GRAMATICA*) malloc (sizeof(GRAMATICA));
    inializarGramatica(G1);
    int tamAnt;
    do
    {
        tamAnt = G1->V.size();
        for (int posProdu = 0; posProdu < G->P.size(); posProdu++)
        {
            bool aceito;
            for (int pos = 2; pos < G->P[posProdu].length(); pos++)
            {
                aceito = false;
                for (int i = 0; i < G->T.size(); i++)
                {
                    if (G->T[i] == G->P[posProdu][pos])
                    {
                        aceito = true;
                        break;
                    }
                }
                if (!aceito)
                {
                    for (int i = 0; i < G1->V.size(); i++)
                    {
                        if (G1->V[i] == G->P[posProdu][pos])
                        {
                            aceito = true;
                            break;
                        }
                    }
                }
                if (!aceito)
                {
                    break;
                }
            }
            if (aceito)
            {
                bool inserir = true;
                for (int i = 0; i < G1->V.size(); i++)
                {
                    if (G1->V[i] == G->P[posProdu][0])
                    {
                        inserir = false;
                        break;
                    }
                }
                if (inserir)
                {
                    int j = G1->V.size();
                    G1->V.push_back(G->P[posProdu][0]);
                }
                inserir = true;
                for (int i = 0; i < G1->P.size(); i++)
                {
                    if (G1->P[i] == G->P[posProdu])
                    {
                        inserir = false;
                        break;
                    }
                }
                if (inserir)
                {
                    inserirProducao(G1, G->P[posProdu]);
                }
            }
        }
    }
    while (G1->V.size() != tamAnt);
    return G1;
}
