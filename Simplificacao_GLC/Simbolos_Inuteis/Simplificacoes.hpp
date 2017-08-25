#ifndef SIMPLIFICACOES_HPP_INCLUDED
#define SIMPLIFICACOES_HPP_INCLUDED

#include <iostream>
#include <cstdio>
#include <cstdlib>

using namespace std;

typedef struct
{
    string w;
} REGISTRO;

typedef struct aux
{
    REGISTRO *elem;
    struct aux *prox;
} ELEMENTO;

typedef ELEMENTO* PONT;

typedef struct
{
    PONT inicio;
} LISTA;

typedef struct
{
    LISTA V, T, P;
    char S;
} GRAMATICA;

void iniGramatica(GRAMATICA*);
void inicializarLista(LISTA*);
int tamanhoLista(LISTA*);
void exibirLista(LISTA*);
void reinicializarLista(LISTA*);
void inserirElemLista(LISTA*, string);

#endif // SIMPLIFICACOES_HPP_INCLUDED
