using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplificacao_GLC_Novo
{
    class ConjuntoFecho
    {
        private List<Fecho> fechos;

        public ConjuntoFecho()
        {
            Fechos = new List<Fecho>();
        }

        internal List<Fecho> Fechos { get => Fechos; set => Fechos = value; }

        public void inserirVariavel(Fecho f)
        {
            if (!Fechos.Contains(f))
            {
                Fechos.Add(f);
            }
        }
    }
}
