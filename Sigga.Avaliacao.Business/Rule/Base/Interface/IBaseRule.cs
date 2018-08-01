using Sigga.Avaliacao.Business.Core.Interface;
using Sigga.Avaliacao.Data.Mapper.Base.Interface;
using Sigga.Avaliacao.Model.Condition.Interface;
using Sigga.Avaliacao.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Business.Rule.Base.Interface
{
    public interface IBaseRule<T> : ICoreRule where T : class
    {
        IBaseMapper<T> Mapper { get; set; }

        EntityResponse<T> Retrieve(Guid id);

        EntityResponse<T> RetrieveFirst(IModelCondition<T> condition);

        EntityCollectionResponse<T> RetrieveCollection(IModelCondition<T> condition);

        CreateResponse Create(T entity);

        CreateCollectionResponse CreateCollection(T[] collection);

        UpdateResponse Update(T entity);

        UpdateResponse UpdateCollection(T[] collection);

        DeleteResponse Delete(Guid id);

        DeleteResponse DeleteCollection(IModelCondition<T> condition);
    }
}
