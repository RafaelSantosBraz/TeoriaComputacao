#include "Simplificacoes.hpp"

void iniGramatica(GRAMATICA *G) // inicializar a gramática com os valores iniciais
{
    inicializarLista(&G->V);
    inicializarLista(&G->T);
    inicializarLista(&G->P);
    G->S = 'S';
}

void inicializarLista(LISTA *l)  // define o estado inicial da lista
{
    l->inicio = NULL;
}

int tamanhoLista(LISTA *l) // realiza a contagem e retora o tamanho da lista
{
    int tam = 0;
    PONT atual = l->inicio;
    while (atual != NULL)
    {
        atual = atual->prox;
        tam++;
    }
    return tam;
}

void exibirLista(LISTA *l) // exibe o conteúdo da lista
{
    PONT atual = l->inicio;
    printf("LISTA: ");
    while (atual != NULL)
    {
        printf(" %s", atual->elem->w);
        atual = atual->prox;
    }
    printf("\n");
}

void reinicializarLista(LISTA *l)  // retorna a lista ao seu estado inicial - elimina todos os elementos
{
    PONT atual = l->inicio;
    while (atual != NULL)
    {
        PONT apagar = atual;
        atual = atual->prox;
        free(apagar);
    }
    l->inicio = NULL;
}

void inserirElemLista(LISTA *l, string elem) // insere um elemento na lista - sempre no final
{
    PONT atual = l->inicio;
    PONT ant = NULL;
    while(atual != NULL)
    {
        ant = atual;
        atual = atual->prox;
    }
    atual = (PONT) malloc(sizeof(ELEMENTO));
    atual->elem = elem;
    if (ant == NULL)
    {
        atual->prox = l->inicio;
        l->inicio = atual;
    }
    else
    {
        atual->prox = ant->prox;
        ant->prox = atual;
    }
}
