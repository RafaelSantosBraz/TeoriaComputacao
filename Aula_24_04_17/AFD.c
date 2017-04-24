#include <stdlib.h>
#include <stdio.h>

int delta(int q, char s){
    switch (q){
        case 0: {
            if (s == 'a'){
                return 1;
            }
            if (s == 'b'){
                return 2;
            }
            break;
        }
        case 1: {
            if (s == 'a'){
                return 3;
            }
            if (s == 'b'){
                return 2;
            }
            break;
        }
        case 2: {
            if (s == 'a'){
                return 1;
            }
            if (s == 'b'){
                return 3;
            }
            break;
        }
        case 3: {
            if (s == 'a' || s == 'b'){
                return 3;
            }
            break;
        }
        
    }
    return -1;
}

int maquinaEstados(char w[], int tam){
    int c, resultado = 0;
    for (c = 0; c < tam; c++){
        resultado = delta(resultado, w[c]);
        if (resultado == -1){
            return -1;
        }
    }
    if (resultado == 3){
        return 0;
    }
    return -1;
}

int main(){
    char palavra[] = {'a', 'b', 'a', 'a', 'b'};
    if (maquinaEstados(palavra, sizeof(palavra)/sizeof(char)) != -1){
        printf("ACEITA\n");
    } else{
        printf("REJEITADA\n");
    }
    return 0;
}
