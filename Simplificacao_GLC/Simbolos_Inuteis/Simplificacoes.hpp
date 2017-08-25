#ifndef SIMPLIFICACOES_HPP_INCLUDED
#define SIMPLIFICACOES_HPP_INCLUDED

#include <iostream>
#include <vector>

using namespace std;

typedef struct
{
    vector<char> V, T, S;
    vector<string> P;
} GRAMATICA;

void iniGramatica(GRAMATICA*);
void inserirV(GRAMATICA*, string);
void inserirT(GRAMATICA*, string);
void inserirP(GRAMATICA*, string*, int);

#endif // SIMPLIFICACOES_HPP_INCLUDED
