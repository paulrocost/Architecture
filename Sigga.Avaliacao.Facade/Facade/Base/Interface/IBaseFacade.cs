using Sigga.Avaliacao.Business.Rule.Base.Interface;
using Sigga.Avaliacao.Facade.Core.Interface;
using Sigga.Avaliacao.Model.Condition.Interface;
using Sigga.Avaliacao.Model.Response;
using System;

namespace Sigga.Avaliacao.Facade.Facade.Base.Interface
{
    public interface IBaseFacade<T> : ICoreFacade where T : class
    {
        IBaseRule<T> Rule { get; set; }

        EntityResponse<T> Retrieve(int id);

        EntityCollectionResponse<T> RetrieveCollection(IModelCondition<T> condition);

        CreateResponse Create(T entity);

        CreateCollectionResponse CreateCollection(T[] collection);

        UpdateResponse Update(T entity);

        UpdateResponse UpdateCollection(T[] collection);

        DeleteResponse Delete(Guid id);
    }
}
