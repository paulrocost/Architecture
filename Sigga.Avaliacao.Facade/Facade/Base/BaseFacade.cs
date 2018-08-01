using Sigga.Avaliacao.Business.Rule.Base.Interface;
using Sigga.Avaliacao.Facade.Facade.Base.Interface;
using Sigga.Avaliacao.Model.Condition.Interface;
using Sigga.Avaliacao.Model.Response;
using System;

namespace Sigga.Avaliacao.Facade.Facade.Base
{
    public abstract class BaseFacade<T>
        : IBaseFacade<T> where T : class
    {

        public IBaseRule<T> Rule { get; set; }

        public BaseFacade()
        {
            this.InstanceRule();
        }

        public abstract void InstanceRule();

        public virtual EntityResponse<T> Retrieve(Guid id)
        {
            return this.Rule.Retrieve(id);
        }

        public virtual EntityCollectionResponse<T> RetrieveCollection(IModelCondition<T> condition)
        {
            return this.Rule.RetrieveCollection(condition);
        }

        public virtual CreateResponse Create(T entity)
        {
            return this.Rule.Create(entity);
        }

        public virtual CreateCollectionResponse CreateCollection(T[] collection)
        {
            return this.Rule.CreateCollection(collection);
        }

        public virtual UpdateResponse Update(T entity)
        {
            return this.Rule.Update(entity);
        }

        public virtual UpdateResponse UpdateCollection(T[] collection)
        {
            return this.Rule.UpdateCollection(collection);
        }

        public virtual DeleteResponse Delete(Guid id)
        {
            return this.Rule.Delete(id);
        }

        #region Dispose
        private bool disposed = false;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                this.Rule.Dispose();

            disposed = true;
        }
        #endregion


    }
}
