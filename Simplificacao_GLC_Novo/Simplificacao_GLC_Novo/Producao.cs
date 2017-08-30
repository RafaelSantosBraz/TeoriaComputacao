using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplificacao_GLC_Novo
{
    class Producao
    {
        private List<String> producoes;

        public Producao()
        {
            Producoes = new List<string>();
        }

        public List<string> Producoes { get => producoes; set => producoes = value; }

        public void inserirProducao(String prod)
        {
            if (!Producoes.Contains(prod))
            {
                Producoes.Add(prod);
            }
        }
    }
}
