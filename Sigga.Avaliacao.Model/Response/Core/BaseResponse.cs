using Sigga.Avaliacao.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Model.Response.Core
{
    public class BaseResponse
    {
        public bool Success { get; private set; }

        public string Message { get; set; }

        public Exception Exception { get; internal set; }

        public bool SessionExpired { get; set; }

        public BaseResponse(bool success)
        {
            this.Success = success;
        }

        public BaseResponse(Exception exception)
            : this(false)
        {
            this.Exception = exception;

            //ToDo: implementar generic exception - mensagem padrao do sistema
            if (!exception.IsNull())
                this.Message = exception.Message;
        }
    }
}
