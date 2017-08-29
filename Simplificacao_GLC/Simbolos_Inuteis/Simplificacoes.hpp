#ifndef SIMPLIFICACOES_HPP_INCLUDED
#define SIMPLIFICACOES_HPP_INCLUDED

#include <iostream>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <vector>

using namespace std;

typedef struct
{
    vector<char> V, T;
    vector<string> P;
    char S;
} GRAMATICA;

void inializarGramatica(GRAMATICA*);
void inserirVariavel(GRAMATICA*, string);
void inserirTerminal(GRAMATICA*, string);
void inserirProducao(GRAMATICA*, string);
GRAMATICA* simbolosInuteisEtapa1(GRAMATICA*);

#endif // SIMPLIFICACOES_HPP_INCLUDED
