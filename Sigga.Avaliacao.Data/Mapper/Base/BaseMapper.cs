using Sigga.Avaliacao.Data.Core;
using Sigga.Avaliacao.Data.Mapper.Base.Interface;
using Sigga.Avaliacao.Model.Condition.Interface;
using Sigga.Avaliacao.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Data.Mapper.Base
{
    public class BaseMapper<T>
        : CoreMapper<T>, IBaseMapper<T> where T : class
    {
        public CreateResponse Create(T entity)
        {
            throw new NotImplementedException();
        }

        public CreateCollectionResponse CreateCollection(T[] collection)
        {
            throw new NotImplementedException();
        }

        public DeleteResponse Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public DeleteResponse DeleteCollection(IModelCondition<T> condition)
        {
            throw new NotImplementedException();
        }

        public EntityResponse<T> Retrieve(Guid id)
        {
            throw new NotImplementedException();
        }

        public EntityCollectionResponse<T> RetrieveCollection(IModelCondition<T> condition)
        {
            throw new NotImplementedException();
        }

        public UpdateResponse Update(T entity)
        {
            throw new NotImplementedException();
        }

        public UpdateResponse UpdateCollection(T[] collection)
        {
            throw new NotImplementedException();
        }
    }
}
