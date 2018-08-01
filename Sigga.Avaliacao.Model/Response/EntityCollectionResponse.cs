using Sigga.Avaliacao.Model.Response.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sigga.Avaliacao.Model.Response
{
    public class EntityCollectionResponse<T> : BaseResponse
    {
        public T[] Collection { get; private set; }

        public EntityCollectionResponse(T[] collection)
            : base(true)
        {
            this.Collection = collection;
        }

        public EntityCollectionResponse(List<T> collection)
            : this(collection.ToArray())
        { }

        public EntityCollectionResponse(IEnumerable<T> collection)
            : this(collection.ToArray())
        { }

        public EntityCollectionResponse(Exception exception)
            : base(exception)
        { }
    }
}
