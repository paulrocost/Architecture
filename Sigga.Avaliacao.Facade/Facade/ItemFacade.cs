using Sigga.Avaliacao.Facade.Facade.Base;
using Sigga.Avaliacao.Facade.Facade.Interface;
using Sigga.Avaliacao.Model.Entity;
using System;

namespace Sigga.Avaliacao.Facade.Facade
{
    public class ItemFacade : BaseFacade<Item>, IItemFacade
    {
        public override void InstanceRule()
        {
            throw new NotImplementedException();
        }        

        #region[Dispose]
        private bool disposed = false;
        public virtual void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                //this.Rule.Dispose();

                disposed = true;
        }

        
        #endregion
    }
}
