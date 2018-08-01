using Sigga.Avaliacao.Facade.Core.Interface;
using System;

namespace Sigga.Avaliacao.Facade.Core
{
    public class CoreFacade : ICoreFacade
    {
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
