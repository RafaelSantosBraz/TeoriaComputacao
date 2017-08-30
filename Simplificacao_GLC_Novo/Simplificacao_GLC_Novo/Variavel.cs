using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplificacao_GLC_Novo
{
    class Variavel
    {
        private List<char> variaveis;

        public Variavel()
        {
            Variaveis = new List<char>();
        }

        public List<char> Variaveis { get => variaveis; set => variaveis = value; }

        public void inserirVariavel(char var)
        {
            if (!Variaveis.Contains(var))
            {
                Variaveis.Add(var);
            }
        }

    }
}
