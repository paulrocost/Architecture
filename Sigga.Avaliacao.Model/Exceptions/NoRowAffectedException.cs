using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Model.Exceptions
{
    public class NoRowAffectedException : Exception
    {
        public NoRowAffectedException()
            :base("Nenhum registro encontrado")
        {
        }
    }
}
