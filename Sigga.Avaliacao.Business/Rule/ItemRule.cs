using Sigga.Avaliacao.Business.Rule.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Business.Rule
{
    public class ItemRule : IItemRule
    {
        public ItemRule()
        {

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
