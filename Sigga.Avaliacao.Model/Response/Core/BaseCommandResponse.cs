using Sigga.Avaliacao.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Model.Response.Core
{
    public class BaseCommandResponse : BaseResponse
    {
        public int Affected { get; private set; }

        public BaseCommandResponse(int affected)
            : base(!affected.Equals(0))
        {
            this.Affected = affected;

            if (!base.Success)
                this.Exception = new NoRowAffectedException { };
        }

        public BaseCommandResponse(Exception exception)
            : base(exception)
        { }
    }
}
