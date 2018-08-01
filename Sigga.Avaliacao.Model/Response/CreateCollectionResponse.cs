using Sigga.Avaliacao.Model.Response.Core;
using System;

namespace Sigga.Avaliacao.Model.Response
{
    public class CreateCollectionResponse : BaseCommandResponse
    {
        public Guid[] CollectionId { get; set; }

        public CreateCollectionResponse(int affected)
            : base(affected)
        { }

        public CreateCollectionResponse(Exception exception)
            : base(exception)
        { }
    }
}
