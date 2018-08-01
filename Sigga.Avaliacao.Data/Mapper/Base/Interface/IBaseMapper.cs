using Sigga.Avaliacao.Data.Core.Interface;
using Sigga.Avaliacao.Model.Condition.Interface;
using Sigga.Avaliacao.Model.Response;
using System;

namespace Sigga.Avaliacao.Data.Mapper.Base.Interface
{
    public interface IBaseMapper<T> : ICoreMapper where T : class
    {
        EntityResponse<T> Retrieve(Guid id);

        EntityCollectionResponse<T> RetrieveCollection(IModelCondition<T> condition);

        CreateResponse Create(T entity);

        CreateCollectionResponse CreateCollection(T[] collection);

        UpdateResponse Update(T entity);

        UpdateResponse UpdateCollection(T[] collection);

        DeleteResponse Delete(Guid id);

        DeleteResponse DeleteCollection(IModelCondition<T> condition);
    }
}
