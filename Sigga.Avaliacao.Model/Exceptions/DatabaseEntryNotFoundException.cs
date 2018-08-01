using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Model.Exceptions
{
    public class DatabaseEntryNotFoundException : Exception
    {
        public DatabaseEntryNotFoundException()
            : base("Registro não encontrado no banco de dados")
        { }
    }
}
