using Sigga.Avaliacao.Business.Rule.Base.Interface;
using Sigga.Avaliacao.Common;
using Sigga.Avaliacao.Data.Mapper.Base.Interface;
using Sigga.Avaliacao.Model.Condition.Interface;
using Sigga.Avaliacao.Model.Exceptions;
using Sigga.Avaliacao.Model.Response;
using System;
using System.Linq;

namespace Sigga.Avaliacao.Business.Rule.Base
{
    public abstract class BaseRule<T>
        : IBaseRule<T> where T : class
    {
        public IBaseMapper<T> Mapper { get; set; }

        public BaseRule()
        {
            this.InstanceMapper();
        }

        public abstract void InstanceMapper();

        public virtual EntityResponse<T> Retrieve(int id)
        {
            try
            {
                return Mapper.Retrieve(id);
            }
            catch (Exception exception)
            {               
                return new EntityResponse<T>(exception);
            }
        }

        public virtual EntityResponse<T> RetrieveFirst(IModelCondition<T> condition)
        {
            try
            {
                var response = this.RetrieveCollection(condition);
                if (!response.Success)
                    throw response.Exception;

                if (response.Collection.IsEmpty())
                    throw new DatabaseEntryNotFoundException { };

                return new EntityResponse<T>(response.Collection.First());
            }
            catch (Exception exception)
            {                
                return new EntityResponse<T>(exception);
            }
        }

        public virtual EntityCollectionResponse<T> RetrieveCollection(IModelCondition<T> condition)
        {
            try
            {
                return Mapper.RetrieveCollection(condition);
            }
            catch (Exception exception)
            {               
                return new EntityCollectionResponse<T>(exception);
            }
        }

        public virtual CreateResponse Create(T entity)
        {
            try
            {               
                return Mapper.Create(entity);
            }
            catch (Exception exception)
            {                
                return new CreateResponse(exception);
            }
        }

        public virtual CreateCollectionResponse CreateCollection(T[] collection)
        {
            try
            {                
                return Mapper.CreateCollection(collection);
            }
            catch (Exception exception)
            {             
                return new CreateCollectionResponse(exception);
            }
        }

        public virtual UpdateResponse Update(T entity)
        {
            try
            {
                return Mapper.Update(entity);
            }
            catch (Exception exception)
            {                
                return new UpdateResponse(exception);
            }
        }

        public virtual UpdateResponse UpdateCollection(T[] collection)
        {
            try
            {
                return Mapper.UpdateCollection(collection);
            }
            catch (Exception exception)
            {                
                return new UpdateResponse(exception);
            }
        }

        public virtual DeleteResponse Delete(Guid id)
        {
            try
            {
                return Mapper.Delete(id);
            }
            catch (Exception exception)
            {
                return new DeleteResponse(exception);
            }
        }

        public virtual DeleteResponse DeleteCollection(IModelCondition<T> condition)
        {
            try
            {
                return Mapper.DeleteCollection(condition);
            }
            catch (Exception exception)
            {
                return new DeleteResponse(exception);
            }
        }

        #region Dispose
        private bool disposed = false;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                this.Mapper.Dispose();

            disposed = true;
        }
        #endregion
    }
}
