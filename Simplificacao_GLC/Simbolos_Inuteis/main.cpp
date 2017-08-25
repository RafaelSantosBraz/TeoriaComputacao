#include "Simplificacoes.hpp"

#define TAMV 4

int main()
{
    GRAMATICA G;
    string V[] = {"S", "A", "B", "C"};
    iniGramatica(&G);
    for (int c = 0; c < TAMV; c++)
    {
        string x = V[c];
        inserirElemLista(&G.V, x);
    }
    exibirLista(&G.V);
    return 0;
}
