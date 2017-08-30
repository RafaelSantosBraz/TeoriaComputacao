using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplificacao_GLC_Novo
{
    class Terminal
    {
        private List<char> terminais;

        public Terminal()
        {
            Terminais = new List<char>();
        }

        public List<char> Terminais { get => terminais; set => terminais = value; }

        public void inserirTerminal(char term)
        {
            if (!Terminais.Contains(term))
            {
                Terminais.Add(term);
            }
        }
    }
}
