using Sigga.Avaliacao.Model.Response.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Model.Response
{
    public class DeleteResponse : BaseCommandResponse
    {
        public DeleteResponse(int affected)
            : base(affected)
        { }

        public DeleteResponse(Exception exception)
            : base(exception)
        { }
    }
}
