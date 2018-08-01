using Sigga.Avaliacao.Model.Response.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Model.Response
{
    public class UpdateResponse : BaseCommandResponse
    {
        public UpdateResponse(int affected)
            : base(affected)
        { }

        public UpdateResponse(Exception exception)
            : base(exception)
        { }
    }
}
