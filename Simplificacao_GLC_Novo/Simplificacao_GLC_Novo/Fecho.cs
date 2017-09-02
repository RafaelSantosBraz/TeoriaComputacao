using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplificacao_GLC_Novo
{
    class Fecho
    {
        private char var;
        private List<char> subs;

        public Fecho(char var)
        {
            this.Var = var;
            Subs = new List<char>();
        }

        public char Var { get => var; set => var = value; }
        public List<char> Subs { get => subs; set => subs = value; }

        public void inserirSubstituicao(char var)
        {
            if (!Subs.Contains(var))
            {
                Subs.Add(var);
            }
        }
    }
}
