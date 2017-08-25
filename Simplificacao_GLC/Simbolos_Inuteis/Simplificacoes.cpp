#include "Simplificacoes.hpp"

void iniGramatica(GRAMATICA *G) // inicializar a gramática com os valores iniciais
{
    G->V.clear();
    G->T.clear();
    G->P.clear();
    G->S.clear();
    G->S.push_back('S');
}

void inserirV(GRAMATICA *G, string vars)
{
    for (int c = 0; c < vars.length(); c++)
    {
        G->V.push_back(vars[c]);
    }
}

void inserirT(GRAMATICA *G, string terms)
{
    for (int c = 0; c < terms.length(); c++)
    {
        G->T.push_back(terms[c]);
    }
}

void inserirP(GRAMATICA *G, string *produ, int tam)
{
    for (int c = 0; c < tam; c++)
    {
        G->P.push_back(produ[c]);
    }
}
