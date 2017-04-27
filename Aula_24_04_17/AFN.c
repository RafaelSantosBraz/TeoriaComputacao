#include <stdlib.h>
#include <stdio.h>

typedef struct aux{
    int estado;
    struct aux *prox;
} estados;

typedef struct{
    estados *inicio;
} fila;

void inicializarFila(fila *f){
    f->inicio = NULL;
}

void exibir(fila *f){
    estados *atual = f->inicio;
    printf("FILA: ");
    while (atual != NULL){
        printf(" %d", atual->estado);
        atual = atual->prox;
    }
    printf("\n");
}

void removerElem(fila *f){
    estados *apagar = f->inicio;
    if (apagar != NULL){
        if (apagar->prox != NULL){
            f->inicio = apagar->prox;
            free(apagar);
        } else{
            f->inicio = NULL;
            free(apagar);
        }
    }
}

void adicionarElem(fila *f, int estado){
    estados *atual = (estados*) malloc(sizeof(estados));
    estados *ant = NULL;
    estados *cont = f->inicio;
    atual->prox = NULL;
    atual->estado = estado;
    if (f->inicio == NULL){
        f->inicio = atual;
    } else{
        while (cont != NULL){
            ant = cont;
            cont = cont->prox;
        }
        ant->prox = atual;
    }
}

int tamanho(fila *f){
    estados *cont = f->inicio;
    int tam = 0;
    while (cont != NULL){
        tam++;
        cont = cont->prox;
    }
    return tam;
}

void delta(int q, char s, fila *f){
    switch (q){
        case 0: {
            if (s == 'a'){
                adicionarElem(f, 0);
                adicionarElem(f, 1);
            }
            if (s == 'b'){
                adicionarElem(f, 0);
                adicionarElem(f, 2);
            }
            break;
        }
        case 1: {
            if (s == 'a'){
                adicionarElem(f, 3);
            }
            break;
        }
        case 2: {
            if (s == 'b'){
                adicionarElem(f, 3);
            }
            break;
        }
        case 3: {
            if (s == 'a' || s == 'b'){
                adicionarElem(f, 3);
            }
            break;
        }

    }
}

int maquinaEstados(char w[], int tam){
    int c, cont;
    fila x;
    inicializarFila(&x);
    adicionarElem(&x, 0);
    for (c = 0; c < tam; c++){
        int taman = tamanho(&x);
        estados *estado = x.inicio;
        for (cont = 1; cont <= taman; cont++){
            printf("tamanho %d simbolo %c\n", taman, w[c]);
            exibir(&x);
            delta(estado->estado, w[c], &x);
            estado = estado->prox;
            removerElem(&x);
        }
        printf("tamanho %d simbolo %c\n", taman, w[c]);
        exibir(&x);
    }
    estados *estado = x.inicio;
    while (estado != NULL){
        if (estado->estado == 3){
            return 0;
        }
        estado = estado->prox;
    }
    return -1;
}

int main(){
    char palavra[] = {'a', 'b', 'a', 'b', 'a'};
    if (maquinaEstados(palavra, sizeof(palavra)/sizeof(char)) != -1){
        printf("ACEITA\n");
    } else{
        printf("REJEITADA\n");
    }
    return 0;
}
