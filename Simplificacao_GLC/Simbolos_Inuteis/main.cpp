#include "Simplificacoes.hpp"

int main()
{
    GRAMATICA G;
    iniGramatica(&G);
    inserirV(&G, "SABC");
    inserirT(&G, "abc");
    string producoes[] = {"S=aAa|bBb", "A=a|S", "C=c"};
    inserirP(&G, producoes, producoes.size());
    return 0;
}
