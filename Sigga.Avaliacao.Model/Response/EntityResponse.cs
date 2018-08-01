using Sigga.Avaliacao.Common;
using Sigga.Avaliacao.Model.Exceptions;
using Sigga.Avaliacao.Model.Response.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Model.Response
{
    public class EntityResponse<T> : BaseResponse
    {
        public T Entity { get; private set; }

        public EntityResponse(object entity)
            : base(entity is T)
        {
            if (entity.IsNull())
                base.Exception = new DatabaseEntryNotFoundException { };

            if (entity is T)
                this.Entity = (T)entity;
        }

        public EntityResponse(Exception exception)
            : base(exception)
        { }
    }
}
