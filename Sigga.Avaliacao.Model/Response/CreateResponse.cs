using Sigga.Avaliacao.Common;
using Sigga.Avaliacao.Model.Response.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Model.Response
{
    public class CreateResponse : BaseResponse
    {
        public int Affected { get; set; }
        public Guid Id { get; private set; }

        public CreateResponse(Guid id)
            : base(!id.IsEmpty())
        {
            this.Id = id;
        }
        public CreateResponse(int affected)
            : base(!affected.Equals(0))
        {
            this.Affected = affected;
            this.InstanceMessage();
        }

        public CreateResponse(Exception exception)
            : base(exception)
        { }

        private void InstanceMessage()
        {
            if (base.Success)
                base.Message = "Registro criado com sucesso";

            else
                base.Message = "Não foi possível criar o registro";
        }
    }
}
