#include "Simplificacoes.hpp"

#define TAMP 5

int main()
{
    GRAMATICA G;
    string P[] = {"S=aAa", "S=bBb", "A=a", "A=S", "C=c"};
    inializarGramatica(&G);
    inserirVariavel(&G, "SABC");
    inserirTerminal(&G, "abc");
    for (int i = 0; i < TAMP; i++)
    {
        inserirProducao(&G, P[i]);
    }
    cout << G.T.size();
    GRAMATICA *G1 = simbolosInuteisEtapa1(&G);
    for (int i = 0; i < G1->V.size(); i++)
    {
        printf(" %c", G1->V[i]);
    }
    return 0;
}
